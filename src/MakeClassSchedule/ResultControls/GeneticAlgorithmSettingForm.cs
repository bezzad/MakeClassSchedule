using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace MakeClassSchedule.ResultControls
{
    public partial class GeneticAlgorithmSettingForm : Form
    {
        public GeneticAlgorithmSettingForm()
        {
            InitializeComponent();
        }

        private void numNumberOfChromosomes_ValueChanged(object sender, EventArgs e)
        {
            if (numTrackBest.Value >= numNumberOfChromosomes.Value)
                numTrackBest.Value = numNumberOfChromosomes.Value - 1;

            if (numReplaceByGeneration.Value > numNumberOfChromosomes.Value - numTrackBest.Value)
                numReplaceByGeneration.Value = numNumberOfChromosomes.Value - numTrackBest.Value;
        }

        private void numReplaceByGeneration_ValueChanged(object sender, EventArgs e)
        {
            if (numReplaceByGeneration.Value > numNumberOfChromosomes.Value - numTrackBest.Value)
            {
                numNumberOfChromosomes.Value = numReplaceByGeneration.Value + numTrackBest.Value;
            }
        }

        private void numTrackBest_ValueChanged(object sender, EventArgs e)
        {
            if (numTrackBest.Value >= numNumberOfChromosomes.Value)
                numNumberOfChromosomes.Value = numTrackBest.Value + numReplaceByGeneration.Value;

            if (numReplaceByGeneration.Value > numNumberOfChromosomes.Value - numTrackBest.Value)
                numReplaceByGeneration.Value = numNumberOfChromosomes.Value - numTrackBest.Value;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (numNumberOfChromosomes.Value < 2) numNumberOfChromosomes.Value = 2;

            if (numTrackBest.Value >= numNumberOfChromosomes.Value)
                numTrackBest.Value = numNumberOfChromosomes.Value - 1;

            if (numReplaceByGeneration.Value > numNumberOfChromosomes.Value - numTrackBest.Value)
                numReplaceByGeneration.Value = numNumberOfChromosomes.Value - numTrackBest.Value;

            Algorithm.Schedule prototype = new Algorithm.Schedule(
                (int)numNumberOfCrossoverPoints.Value,
                (int)numMutationSize.Value,
                (int)numCrossoverProbability.Value,
                (int)numMutationProbability.Value);

            Algorithm.Schedule.ScheduleObserver sso = new Algorithm.Schedule.ScheduleObserver();
            sso.SetWindow(ResultForm.create_GridView);
            ResultForm.AA = new MakeClassSchedule.Algorithm.Algorithm(
                (int)numNumberOfChromosomes.Value,
                (int)numReplaceByGeneration.Value,
                (int)numTrackBest.Value,
                prototype, sso);

            this.Dispose();
        }

        private void GeneticAlgorithmSettingForm_Load(object sender, EventArgs e)
        {
            numNumberOfCrossoverPoints.Value = ResultForm.AA.NumberOfCrossoverPoints;
            numNumberOfCrossoverPoints.KeyDown += new KeyEventHandler(num_KeyDown);
            numMutationSize.Value = ResultForm.AA.MutationSize;
            numMutationSize.KeyDown += new KeyEventHandler(num_KeyDown);
            numCrossoverProbability.Value = ResultForm.AA.CrossoverProbability;
            numCrossoverProbability.KeyDown += new KeyEventHandler(num_KeyDown);
            numMutationProbability.Value = ResultForm.AA.MutationProbability;
            numMutationProbability.KeyDown += new KeyEventHandler(num_KeyDown);
            numNumberOfChromosomes.Value = ResultForm.AA.NumberOfChromosomes;
            numNumberOfChromosomes.KeyDown += new KeyEventHandler(num_KeyDown);
            numTrackBest.Value = ResultForm.AA.TrackBest;
            numTrackBest.KeyDown += new KeyEventHandler(num_KeyDown);
            numReplaceByGeneration.Value = ResultForm.AA.ReplaceByGeneration;
            numReplaceByGeneration.KeyDown += new KeyEventHandler(num_KeyDown);
        }

        private void num_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (!this.SelectNextControl((Control)sender, true, true, true, false))
                {
                    btnSave_Click(sender, e);
                }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {
            numNumberOfCrossoverPoints.Value = 5;
            numMutationSize.Value = 5;
            numCrossoverProbability.Value = 90;
            numMutationProbability.Value = 10;
            numNumberOfChromosomes.Value = 1000;
            numTrackBest.Value = 50;
            numReplaceByGeneration.Value = 180;
        }
    }
}
