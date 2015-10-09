using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SpannedDataGridView
{
    static class DataGridViewCellExHelper
    {
        public static Rectangle GetSpannedCellClipBounds<TCell>(
            TCell ownerCell,
            Rectangle cellBounds,
            bool singleVerticalBorderAdded,
            bool singleHorizontalBorderAdded)
            where TCell : DataGridViewCell, ISpannedCell
        {
            var dataGridView = ownerCell.DataGridView;
            var clipBounds = cellBounds;
            //Setting X (skip invisible columns).
            foreach (var columnIndex in Enumerable.Range(ownerCell.ColumnIndex, ownerCell.ColumnSpan))
            {
                var column = dataGridView.Columns[columnIndex];
                if (!column.Visible)
                    continue;
                if (column.Frozen
                    || columnIndex > dataGridView.FirstDisplayedScrollingColumnIndex)
                {
                    break;
                }
                if (columnIndex == dataGridView.FirstDisplayedScrollingColumnIndex)
                {
                    clipBounds.Width -= dataGridView.FirstDisplayedScrollingColumnHiddenWidth;
                    if (dataGridView.RightToLeft != RightToLeft.Yes)
                    {
                        clipBounds.X += dataGridView.FirstDisplayedScrollingColumnHiddenWidth;
                    }
                    break;
                }
                clipBounds.Width -= column.Width;
                if (dataGridView.RightToLeft != RightToLeft.Yes)
                {
                    clipBounds.X += column.Width;
                }
            }

            //Setting Y.
            foreach (var rowIndex in Enumerable.Range(ownerCell.RowIndex, ownerCell.RowSpan))
            {
                var row = dataGridView.Rows[rowIndex];
                if (!row.Visible)
                    continue;
                if (row.Frozen || rowIndex >= dataGridView.FirstDisplayedScrollingRowIndex)
                {
                    break;
                }
                clipBounds.Y += row.Height;
                clipBounds.Height -= row.Height;
            }

            // exclude borders.
            if (dataGridView.BorderStyle != BorderStyle.None)
            {
                var clientRectangle = dataGridView.ClientRectangle;
                clientRectangle.Width--;
                clientRectangle.Height--;
                if (dataGridView.RightToLeft == RightToLeft.Yes)
                {
                    clientRectangle.X++;
                    clientRectangle.Y++;
                }
                clipBounds.Intersect(clientRectangle);
            }
            return clipBounds;
        }

        public static Rectangle GetSpannedCellBoundsFromChildCellBounds<TCell>(
            TCell childCell,
            Rectangle childCellBounds,
            bool singleVerticalBorderAdded,
            bool singleHorizontalBorderAdded)
            where TCell : DataGridViewCell, ISpannedCell
        {
            var dataGridView = childCell.DataGridView;
            var ownerCell = childCell.OwnerCell as TCell ?? childCell;
            var spannedCellBounds = childCellBounds;
            //
            var firstVisibleColumnIndex = Enumerable.Range(ownerCell.ColumnIndex, ownerCell.ColumnSpan)
                .First(i => dataGridView.Columns[i].Visible);
            if (dataGridView.Columns[firstVisibleColumnIndex].Frozen)
            {
                spannedCellBounds.X = dataGridView.GetColumnDisplayRectangle(firstVisibleColumnIndex, false).X;
            }
            else
            {
                var dx = Enumerable.Range(firstVisibleColumnIndex, childCell.ColumnIndex - firstVisibleColumnIndex)
                    .Select(i => dataGridView.Columns[i])
                    .Where(columnItem => columnItem.Visible)
                    .Sum(columnItem => columnItem.Width);
                spannedCellBounds.X = dataGridView.RightToLeft == RightToLeft.Yes
                                          ? spannedCellBounds.X + dx
                                          : spannedCellBounds.X - dx;
            }
            //
            var firstVisibleRowIndex = Enumerable.Range(ownerCell.RowIndex, ownerCell.RowSpan)
                .First(i => dataGridView.Rows[i].Visible);
            if (dataGridView.Rows[firstVisibleRowIndex].Frozen)
            {
                spannedCellBounds.Y = dataGridView.GetRowDisplayRectangle(firstVisibleRowIndex, false).Y;
            }
            else
            {
                spannedCellBounds.Y -= Enumerable.Range(firstVisibleRowIndex, childCell.RowIndex - firstVisibleRowIndex)
                    .Select(i => dataGridView.Rows[i])
                    .Where(rowItem => rowItem.Visible)
                    .Sum(rowItem => rowItem.Height);
            }
            //
            var spannedCellWidth = Enumerable.Range(ownerCell.ColumnIndex, ownerCell.ColumnSpan)
                .Select(columnIndex => dataGridView.Columns[columnIndex])
                .Where(column => column.Visible)
                .Sum(column => column.Width);
            if (dataGridView.RightToLeft == RightToLeft.Yes)
            {
                spannedCellBounds.X = spannedCellBounds.Right - spannedCellWidth;
            }
            spannedCellBounds.Width = spannedCellWidth;
            //
            spannedCellBounds.Height = Enumerable.Range(ownerCell.RowIndex, ownerCell.RowSpan)
                .Select(rowIndex => dataGridView.Rows[rowIndex])
                .Where(row => row.Visible)
                .Sum(row => row.Height);

            if (singleVerticalBorderAdded && InFirstDisplayedColumn(ownerCell))
            {
                spannedCellBounds.Width++;
                if (dataGridView.RightToLeft != RightToLeft.Yes)
                {
                    if (childCell.ColumnIndex != dataGridView.FirstDisplayedScrollingColumnIndex)
                    {
                        spannedCellBounds.X--;
                    }
                }
                else
                {
                    if (childCell.ColumnIndex == dataGridView.FirstDisplayedScrollingColumnIndex)
                    {
                        spannedCellBounds.X--;
                    }
                }
            }
            if (singleHorizontalBorderAdded && InFirstDisplayedRow(ownerCell))
            {
                spannedCellBounds.Height++;
                if (childCell.RowIndex != dataGridView.FirstDisplayedScrollingRowIndex)
                {
                    spannedCellBounds.Y--;
                }
            }
            return spannedCellBounds;
        }

        public static DataGridViewAdvancedBorderStyle AdjustCellBorderStyle<TCell>(TCell cell)
            where TCell : DataGridViewCell, ISpannedCell
        {
            var dataGridViewAdvancedBorderStylePlaceholder = new DataGridViewAdvancedBorderStyle();
            var dataGridView = cell.DataGridView;
            return cell.AdjustCellBorderStyle(
                dataGridView.AdvancedCellBorderStyle, 
                dataGridViewAdvancedBorderStylePlaceholder,
                dataGridView.SingleVerticalBorderAdded(),
                dataGridView.SingleHorizontalBorderAdded(),
                InFirstDisplayedColumn(cell),
                InFirstDisplayedRow(cell)); 
        }

        public static bool InFirstDisplayedColumn<TCell>(this TCell cell)
            where TCell : DataGridViewCell, ISpannedCell
        {
            var dataGridView = cell.DataGridView;
            return dataGridView.FirstDisplayedScrollingColumnIndex >= cell.ColumnIndex
                   && dataGridView.FirstDisplayedScrollingColumnIndex < cell.ColumnIndex + cell.ColumnSpan;
        }

        public static bool InFirstDisplayedRow<TCell>(this TCell cell)
            where TCell : DataGridViewCell, ISpannedCell
        {
            var dataGridView = cell.DataGridView;
            return dataGridView.FirstDisplayedScrollingRowIndex >= cell.RowIndex
                   && dataGridView.FirstDisplayedScrollingRowIndex < cell.RowIndex + cell.RowSpan;
        }
    }
}