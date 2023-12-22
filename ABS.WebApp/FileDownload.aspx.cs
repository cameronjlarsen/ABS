using ABS.FileGeneration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ABS.WebApp
{
    public partial class FileDownload : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected async void DownloadButton_Click(object sender, EventArgs e)
        {
            HideErrorMessage();
            var fileGenerationService = new FileGenerationService();

            try
            {
                using (FileStream fileStream = await fileGenerationService.GenerateFile())
                {
                    if (fileStream != null)
                    {
                        HttpResponse httpResponse = Response;
                        httpResponse.Clear();
                        httpResponse.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                        httpResponse.AddHeader("Content-Disposition", "attachment;filename=\"HelloWorls.xlsx\"");

                        fileStream.CopyTo(httpResponse.OutputStream);

                        httpResponse.Flush();
                        httpResponse.End();

                    }
                    else
                    {
                        ShowErrorMessage("Failed to generate the file. Please try again.");
                    }
                }

            }
            catch (IOException ex) when (ex is IOException || ex is FileNotFoundException )
            {
                // Log error
                Console.WriteLine("Error", ex);
                ShowErrorMessage("An error occurred while downloading the file.");
            }
        }

        private void ShowErrorMessage(string message)
        {
            ErrorMessageLabel.InnerText = message;
            ErrorMessageLabel.Visible = true;
        }

        private void HideErrorMessage()
        {
            ErrorMessageLabel.InnerText = string.Empty;
            ErrorMessageLabel.Visible = false;
        }
    }
}