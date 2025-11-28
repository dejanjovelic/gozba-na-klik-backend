using gozba_na_klik_backend.Model;
using gozba_na_klik_backend.Services.IServices;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Drawing;
using System.Globalization;

namespace gozba_na_klik_backend.Services
{
    public class PdfGeneratorService : IPdfGeneratorService
    {
        public PdfGeneratorService()
        {
            QuestPDF.Settings.License = LicenseType.Community;
        }

        public byte[] GenerateInvoicePdf(Invoice invoice)
        {
            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(30);

                    page.Header().Text($"Invoice No. {invoice.Id}")
                    .SemiBold().FontSize(18).FontColor(Colors.Blue.Medium);

                    //
                    page.Content().PaddingVertical(10).Column(column =>
                    {

                        column.Item().Row(row =>
                        {

                            row.RelativeItem().Column(col =>
                            {
                                col.Item().Text("Seller: ").Bold();
                                col.Item().Text(invoice.RestaurantName);
                                col.Item().Text(invoice.RestaurantAddress + " " + invoice.RestaurantCity);
                            });

                            row.RelativeItem().Column(col =>
                            {
                                col.Item().Text("Customer:").Bold();
                                col.Item().Text(invoice.CustomerName + " " + invoice.CustomerSurname);
                                col.Item().Text(invoice.DeliveryFullAddress);
                            });

                            row.RelativeItem().AlignRight().Column(col =>
                            {
                                col.Item().Text("Issue date:").Bold();
                                col.Item().Text(invoice.DeliveredAt?.ToString("dd.MM.yyyy."));
                            });

                        });

                        column.Item().PaddingVertical(15).Table(table => 
                        {
                            table.ColumnsDefinition(columns => 
                            {
                                columns.RelativeColumn(5);
                                columns.RelativeColumn(2);
                                columns.RelativeColumn(2);
                                columns.RelativeColumn(2);
                                
                            });

                            table.Header(header => 
                            {
                                header.Cell().BorderBottom(1).Padding(5).Text("Name").Bold();
                                header.Cell().BorderBottom(1).Padding(5).Text("Quantity").Bold();
                                header.Cell().BorderBottom(1).Padding(5).Text("Price").Bold();
                                header.Cell().BorderBottom(1).Padding(5).AlignRight().Text("Total").Bold();
                            });

                            foreach (var item in invoice.OrderedMeals) 
                            {
                                table.Cell().BorderBottom(1).Padding(5).Text(item.MealName);
                                table.Cell().BorderBottom(1).Padding(5).Text(item.Quantity.ToString());
                                table.Cell().BorderBottom(1).Padding(5).Text(item.MealPrice.ToString());
                                table.Cell().BorderBottom(1).Padding(5).AlignRight().Text($"{item.Total.ToString()} €");
                            }
                           
                        });
                        column.Item().AlignRight().Text($"Grand Total: {invoice.TotalPrice} €").Bold();
                        column.Item().AlignLeft().Padding(30).Text($"Issued on the basis of the order number:  {invoice.OrderId}").FontSize(10).Italic();
                    });


                    page.Footer().AlignCenter().Text(x => 
                    {
                        x.Line($"Print date:  {DateTime.Now.ToString("dd.MM.yyyy.")}").FontSize(10);
                        x.Line("www.GozbaNaKlik.rs").FontSize(10).Bold();
                    });
                });
            });

            return document.GeneratePdf();
        }
    }
}
