using System;
using System.Windows.Forms;

namespace DelegatesAndEvents
{
    public partial class Form_Main : Form
    {
        public Form_Main()
        {
            InitializeComponent();
        }

        private void TrackableList_ChangeEvent<T>(object sndr, TrackableListEventArgs<T> ev)
        {
            richTextBox_output.Text += "Old Value: " + ev.OldValue + " New Value: " + ev.NewValue +
                                       " at index: " + ev.Index + " Happened: " + ev.WhatHappened + Environment.NewLine;
        }

        private void do_magic_btn_Click(object sender, EventArgs e)
        {
            richTextBox_output.Text = string.Empty;

            var trackableList = new TrackableList<int>();
            trackableList.ChangeEvent += TrackableList_ChangeEvent;
            trackableList.Add(10);
            trackableList.Add(20);
            trackableList.Insert(0, 13);
            trackableList[0] = 125;
            trackableList[1] = 45;
            trackableList[2] = 55;
            trackableList.Add(40);
            trackableList.Add(50);
            trackableList.Add(60);
            trackableList.Remove(50);
            trackableList.Remove(60);
            trackableList.RemoveAt(2);

            //выведем всю оставшуюся коллекцию, очистим её и выведем опять
            richTextBox_output.Text += Environment.NewLine + "=======================" + Environment.NewLine;
            for (var i = 0; i < trackableList.Count; i++)
                richTextBox_output.Text += "Index: " + i + " Value: " + trackableList[i] + Environment.NewLine;
            richTextBox_output.Text += Environment.NewLine + "=======================" + Environment.NewLine;
            trackableList.Clear();
            for (var i = 0; i < trackableList.Count; i++)
                richTextBox_output.Text += "Index: " + i + " Value: " + trackableList[i] + Environment.NewLine;
        }
    }
}
