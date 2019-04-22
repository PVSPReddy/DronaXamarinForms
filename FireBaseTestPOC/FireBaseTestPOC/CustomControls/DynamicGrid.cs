using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace FireBaseTestPOC.CustomControls
{
    public class DynamicGrid : ContentView
    {

        #region for 
        Grid grid;
        public DynamicGrid()
        {
            SetUpLayout();
        }

        void SetUpLayout()
        {
            grid = new Grid()
            {
                RowDefinitions = {
                    new RowDefinition{ Height = GridLength.Auto }
                },
                ColumnDefinitions = {
                    new ColumnDefinition{ Width = GridLength.Auto }
                },
                BackgroundColor = Color.Maroon,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            var box = new BoxView()
            {
                BackgroundColor = Color.Teal,
                WidthRequest = 50,
                HeightRequest = 50
            };
            grid.Children.Add(box, 0, 0);
            Content = grid;
        }

        public void AlterCells(EffectedSection section, CustomTapEventArgs args)
        {
            try
            {
                if (section == EffectedSection.Column)
                {
                    AlterHorizontalCells(args);
                }
                else if (section == EffectedSection.Row)
                {
                    AlterVerticalCells(args);
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
            }
        }

        private void AlterHorizontalCells(CustomTapEventArgs e)
        {
            try
            {
                if (e.ButtonOption == ButtonOption.Add)
                {
                    grid.RowDefinitions.Add(new RowDefinition()
                    {
                        Height = GridLength.Auto
                    });

                    var rows = grid.RowDefinitions.Count;
                    var columns = grid.ColumnDefinitions.Count;
                    for (int column = 0; column < columns; column++)
                    {
                        var box = new BoxView()
                        {
                            BackgroundColor = Color.Teal,
                            WidthRequest = 50,
                            HeightRequest = 50
                        };
                        grid.Children.Add(box, column, rows - 1);
                    }
                }
                else if (e.ButtonOption == ButtonOption.Delete)
                {
                    var rows = grid.RowDefinitions.Count;
                    var gridChildren = grid.Children;
                    List<View> removableColumnViews = new List<View>();
                    foreach (var child in gridChildren)
                    {
                        var childRow = Grid.GetRow(child);
                        if (childRow == rows)
                        {
                            removableColumnViews.Add(child);
                        }
                    }
                    foreach (var viewItem in removableColumnViews)
                    {
                        grid.Children.Remove(viewItem);
                    }
                    grid.RowDefinitions.Remove(grid.RowDefinitions[grid.RowDefinitions.Count - 1]);
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
            }
        }

        private void AlterVerticalCells(CustomTapEventArgs e)
        {
            try
            {
                if (e.ButtonOption == ButtonOption.Add)
                {
                    grid.ColumnDefinitions.Add(new ColumnDefinition()
                    {
                        Width = GridLength.Auto
                    });

                    var rows = grid.RowDefinitions.Count;
                    var columns = grid.ColumnDefinitions.Count;
                    for (int row = 0; row < rows; row++)
                    {
                        var box = new BoxView()
                        {
                            BackgroundColor = Color.Teal,
                            WidthRequest = 50,
                            HeightRequest = 50,
                        };
                        grid.Children.Add(box, columns - 1, row);
                    }
                }
                else if (e.ButtonOption == ButtonOption.Delete)
                {
                    var columns = grid.ColumnDefinitions.Count;
                    var gridChildren = grid.Children;
                    List<View> removableRowViews = new List<View>();
                    foreach (var child in gridChildren)
                    {
                        var childColumn = Grid.GetColumn(child);
                        if (childColumn == columns)
                        {
                            removableRowViews.Add(child);
                        }
                    }
                    foreach (var viewItem in removableRowViews)
                    {
                        grid.Children.Remove(viewItem);
                    }
                    grid.ColumnDefinitions.Remove(grid.ColumnDefinitions[grid.ColumnDefinitions.Count - 1]);
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
            }
        }
        #endregion



        #region for old code 09/04/2019
        /*
        Grid grid;
        public DynamicGrid()
        {
            SetUpLayout();
        }

        void SetUpLayout()
        {
            grid = new Grid()
            {
                RowDefinitions = {
                    new RowDefinition{ Height = GridLength.Auto }
                },
                ColumnDefinitions = {
                    new ColumnDefinition{ Width = GridLength.Auto }
                },
                BackgroundColor = Color.Maroon,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            var box = new BoxView()
            {
                BackgroundColor = Color.Teal,
                WidthRequest = 50,
                HeightRequest = 50
            };
            grid.Children.Add(box, 0, 0);
            Content = grid;
        }

        public void AlterCells(EffectedSection section, CustomTapEventArgs args)
        {
            try
            {
                if(section == EffectedSection.Column)
                {
                    AlterHorizontalCells(args);
                }
                else if(section == EffectedSection.Row)
                {
                    AlterVerticalCells(args);
                }
                else
                {

                }
            }
            catch(Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
            }
        }

        private void AlterHorizontalCells(CustomTapEventArgs e)
        {
            try
            {
                if (e.ButtonOption == ButtonOption.Add)
                {
                    grid.RowDefinitions.Add(new RowDefinition()
                    {
                        Height = GridLength.Auto
                    });

                    var rows = grid.RowDefinitions.Count;
                    var columns = grid.ColumnDefinitions.Count;
                    for (int column = 0; column < columns; column++)
                    {
                        var box = new BoxView()
                        {
                            BackgroundColor = Color.Teal,
                            WidthRequest = 50,
                            HeightRequest = 50
                        };
                        grid.Children.Add(box, column, rows - 1);
                    }
                }
                else if (e.ButtonOption == ButtonOption.Delete)
                {
                    var rows = grid.RowDefinitions.Count;
                    //var columns = grid.ColumnDefinitions.Count;
                    var gridChildren = grid.Children;
                    List<View> removableColumnViews = new List<View>();
                    foreach (var child in gridChildren)
                    {
                        var childRow = Grid.GetRow(child);
                        //var childColumn = Grid.GetColumn(child);
                        if (childRow == rows)
                        {
                            removableColumnViews.Add(child);
                        }
                        //for (int column = 0; column < columns; column++)
                        //{
                        //    System.Diagnostics.Debug.WriteLine("Adjusting Rows");
                        //    System.Diagnostics.Debug.WriteLine(string.Format("childRow :{0} \n row :{1}", childRow.ToString(), rows.ToString()));
                        //    System.Diagnostics.Debug.WriteLine(string.Format("childColumn :{0} \n columns :{1}", childColumn.ToString(), column.ToString()));
                        //    if (childRow == rows && childColumn == column)
                        //    {
                        //        removableColumnViews.Add(child);
                        //    }
                        //}
                    }
                    foreach (var viewItem in removableColumnViews)
                    {
                        grid.Children.Remove(viewItem);
                    }
                    grid.RowDefinitions.Remove(grid.RowDefinitions[grid.RowDefinitions.Count - 1]);
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
            }
        }

        private void AlterVerticalCells(CustomTapEventArgs e)
        {
            try
            {
                if (e.ButtonOption == ButtonOption.Add)
                {
                    grid.ColumnDefinitions.Add(new ColumnDefinition()
                    {
                        Width = GridLength.Auto
                    });

                    var rows = grid.RowDefinitions.Count;
                    var columns = grid.ColumnDefinitions.Count;
                    for (int row = 0; row < rows; row++)
                    {
                        var box = new BoxView()
                        {
                            BackgroundColor = Color.Teal,
                            WidthRequest = 50,
                            HeightRequest = 50,
                        };
                        grid.Children.Add(box, columns - 1, row);
                    }
                }
                else if (e.ButtonOption == ButtonOption.Delete)
                {
                    //var rows = grid.RowDefinitions.Count;
                    var columns = grid.ColumnDefinitions.Count;
                    var gridChildren = grid.Children;
                    List<View> removableRowViews = new List<View>();
                    foreach(var child in gridChildren)
                    {
                        //var childRow = Grid.GetRow(child);
                        var childColumn = Grid.GetColumn(child);
                        if (childColumn == columns)
                        {
                            removableRowViews.Add(child);
                        }
                        //for (int row = 0; row < rows; row++)
                        //{
                        //    System.Diagnostics.Debug.WriteLine("Adjusting Columns");
                        //    System.Diagnostics.Debug.WriteLine(string.Format("childRow :{0} \n row :{1}", childRow.ToString(), row.ToString()));
                        //    System.Diagnostics.Debug.WriteLine(string.Format("childColumn :{0} \n columns :{1}", childColumn.ToString(), columns.ToString()));
                        //    if (childRow == row && childColumn == columns)
                        //    {
                        //        removableRowViews.Add(child);
                        //    }
                        //}
                    }
                    foreach (var viewItem in removableRowViews)
                    {
                        grid.Children.Remove(viewItem);
                    }
                    grid.ColumnDefinitions.Remove(grid.ColumnDefinitions[grid.ColumnDefinitions.Count - 1]);
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
            }
        }
        */
        #endregion
    }

    public enum EffectedSection
    {
        Column, Row
    }
}