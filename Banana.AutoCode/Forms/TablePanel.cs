﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using Banana.AutoCode.DbSchema;
using System.Configuration;

namespace Banana.AutoCode.Forms
{
    public partial class TablePanel : DockContent
    {
        protected Table Table;
        protected ConnectionStringSettings ConnSetting;

        public TablePanel(Table table, ConnectionStringSettings connSetting)
        {
            InitializeComponent();

            Table = table;
            ConnSetting = connSetting;

            Init();
        }

        public void Init()
        {
            this.dgvColumns.AutoGenerateColumns = false;

            this.txtTable.Text = this.Table.Name;
            this.txtClazz.Text = this.Table.Name;
            this.txtComment.Text = this.Table.Comment;

            if (Table.Columns != null && Table.Columns.Any())
            {
                this.dgvColumns.DataSource = Table;
            }
            else
            {
                this.dgvColumns.DataSource = new DbSchemaManager(ConnSetting).GetColumns(Table);
            }
        }
    }
}
