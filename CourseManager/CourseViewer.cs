﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Objects;
using System.Data.Objects.DataClasses;

namespace CourseManager
{
    public partial class CourseViewer : Form
    {
        //Create an ObjectContext instance based on SchoolEntity
        private SchoolEntities schoolContext;
     
        public CourseViewer()
        {
            InitializeComponent();
        }

        private void closeForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CourseViewer_Load(object sender, EventArgs e)
        {
            //Initialize the ObjectContext
            schoolContext = new SchoolEntities();

            // Define a query that returns all Department  
            // objects and course objects, ordered by name.
            var departmentQuery = from d in schoolContext.Departments.Include("Courses")
                                  orderby d.Name
                                  select d;
            try
            {
                // Bind the ComboBox control to the query, 
                // which is executed during data binding.
                // To prevent the query from being executed multiple times during binding, 
                // it is recommended to bind controls to the result of the Execute method. 
                this.departmentList.DisplayMember = "Name";
                this.departmentList.DataSource = ((ObjectQuery)departmentQuery).Execute(MergeOption.AppendOnly);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void departmentList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Get the object for the selected department.
                Department department = (Department)this.departmentList.SelectedItem;

                // Bind the grid view to the collection of Course objects
                // that are related to the selected Department object.
                courseGridView.DataSource = department.Courses;

                // Hide the columns that are bound to the navigation properties on Course.
                courseGridView.Columns["Department"].Visible = false;
                courseGridView.Columns["StudentGrades"].Visible = false;
                courseGridView.Columns["OnlineCourse"].Visible = false;
                courseGridView.Columns["OnsiteCourse"].Visible = false;
                courseGridView.Columns["People"].Visible = false;
                courseGridView.Columns["DepartmentId"].Visible = false;

                courseGridView.AllowUserToDeleteRows = false;
                courseGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
       
    }
}
