// See https://aka.ms/new-console-template for more information

using iTextSharp.text;
using iTextSharp.text.pdf;
using Spire.Pdf;

try
{
    //using (PdfDocument doc = new PdfDocument())
    //{
    //    doc.LoadFromFile(@"D:\书籍\专业\.NET微服务：容器化.NET应用架构指南.pdf");

    //    var firstPage = doc.Pages[0];
    //    //var image = firstPage.ExtractImages();
    //    //if (image != null && image.Length >= 1)
    //    //{
    //    //    var firstImage = image[0];
    //    //    using (firstImage)
    //    //    {
    //    //        using (MemoryStream ms = new MemoryStream())
    //    //        {
    //    //            firstImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
    //    //            byte[] imageBytes = ms.ToArray();
    //    //            base64String = Convert.ToBase64String(imageBytes);
    //    //        }
    //    //    }
    //    //}
    //}

    ExtractPages(@"D:\书籍\专业\.NET微服务：容器化.NET应用架构指南.pdf", @"C:\Users\刘继光的PC\Desktop\新建文件夹 (2)\111.pdf", 1, 1);

    Console.WriteLine("Hello, World!");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
void ExtractPages(string sourcePdfPath, string outputPdfPath, int startPage, int endPage)
{
    PdfReader reader = null;
    Document sourceDocument = null;
    PdfCopy pdfCopyProvider = null;
    PdfImportedPage importedPage = null;
    try
    {
        reader = new PdfReader(sourcePdfPath);
        sourceDocument = new Document(reader.GetPageSizeWithRotation(startPage));
        pdfCopyProvider = new PdfCopy(sourceDocument, new System.IO.FileStream(outputPdfPath, System.IO.FileMode.Create));
        sourceDocument.Open();
        for (int i = startPage; i <= endPage; i++)
        {
            importedPage = pdfCopyProvider.GetImportedPage(reader, i); pdfCopyProvider.AddPage(importedPage);
        }
        sourceDocument.Close();
        reader.Close();
    }
    catch (Exception ex) { throw ex; }
}
