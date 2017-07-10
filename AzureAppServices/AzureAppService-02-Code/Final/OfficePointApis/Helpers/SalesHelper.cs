using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace OfficePointApis.Helpers
{
    public static class SalesHelper
    {
        private static List<double> GetCurrentSalesValues()
        {
            List<double> values = new List<double>();
            //NEED TO ADD YOUR OWN MODEL AND UNCOMMENT
            //using (DataModels.OfficePointEntities entities = new DataModels.OfficePointEntities())
            //{
            //    entities.Database.Connection.ConnectAndOpen();

            //    try
            //    {
            //        var results = entities.GetSales();

            //        values = results.Select(s => s.SalesInMillions).ToList();

            //    }
            //    catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            //    {

            //    }
            //    finally
            //    {
            //        entities.Database.Connection.Close();
            //    }

            //}

            return values;
        }

        public static byte[] BuildSalesChart()
        {
            List<double> values = GetCurrentSalesValues();

            var chart = GetSalesChartImage(Color.Transparent, 140, 140, values);

            byte[] bmpBytes = GetSalesChartBytes(chart);

            return bmpBytes;
        }

        private static byte[] GetSalesChartBytes(Bitmap chart)
        {
            MemoryStream ms = new MemoryStream();

            chart.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

            byte[] bmpBytes = ms.GetBuffer();

            chart.Dispose();

            ms.Close();

            return bmpBytes;
        }
        private static Bitmap GetSalesChartImage(Color bgColor, int width, int height, List<double> vals)
        {
            Bitmap bitmap = new Bitmap(280, height, PixelFormat.Format32bppArgb);
            Graphics graphics = Graphics.FromImage(bitmap);
            SolidBrush brush = new SolidBrush(bgColor);
            graphics.FillRectangle(brush, 0, 0, width, height);
            brush.Dispose();

            List<SolidBrush> brushes = GetPaletteColors();

            double total = 0.0d;
            foreach (double val in vals) total += val;

            float start = 0.0f;
            float end = 0.0f;
            double current = 0.0d;

            for (int i = 0; i < vals.Count; i++)
            {
                current += vals[i];
                start = end;
                end = (float)(current / total) * 360.0f;
                graphics.FillPie(brushes[i % 10], 0.0f, 0.0f, width, height, start, end - start);
            }

            foreach (SolidBrush cleanBrush in brushes)
                cleanBrush.Dispose();
            return bitmap;
        }
        private static List<SolidBrush> GetPaletteColors()
        {
            List<SolidBrush> brushes = new List<SolidBrush>();

            brushes.Add(new SolidBrush(System.Drawing.ColorTranslator.FromHtml("#70AD47")));
            brushes.Add(new SolidBrush(System.Drawing.ColorTranslator.FromHtml("#4472C4")));
            brushes.Add(new SolidBrush(System.Drawing.ColorTranslator.FromHtml("#FFC000")));
            brushes.Add(new SolidBrush(System.Drawing.ColorTranslator.FromHtml("#ED7D31")));
            brushes.Add(new SolidBrush(System.Drawing.ColorTranslator.FromHtml("#B20000")));
            brushes.Add(new SolidBrush(Color.Gray));
            brushes.Add(new SolidBrush(Color.Black));
            brushes.Add(new SolidBrush(Color.Green));
            brushes.Add(new SolidBrush(Color.Teal));
            brushes.Add(new SolidBrush(Color.Firebrick));

            return brushes;
        }
    }
}