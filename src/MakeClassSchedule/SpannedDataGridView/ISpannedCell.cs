using System.Windows.Forms;

namespace SpannedDataGridView
{
    interface ISpannedCell
    {
        int ColumnSpan { get; }
        int RowSpan { get; }
        DataGridViewCell OwnerCell { get; }
    }
}