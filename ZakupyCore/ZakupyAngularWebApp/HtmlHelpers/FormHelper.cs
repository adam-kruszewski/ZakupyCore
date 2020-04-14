using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace ZakupyAngularWebApp.HtmlHelpers
{
    public static class FormHelper
    {
        public static HelperResult GenerujFormularz(
           this IHtmlHelper helper,
           string actionName,
           string controllerName,
           object model,
           string akcjaAnuluj = null)
        {
            return new HelperResult(writer =>
                GenerujTrescFormularza(helper, actionName, controllerName, writer, model, akcjaAnuluj)
            );
        }

        private static async Task GenerujTrescFormularza(IHtmlHelper helper, string actionName,
            string controllerName, System.IO.TextWriter writer,
            object model,
            string akcjaAnuluj = null)
        {
            using (helper.BeginForm(actionName, controllerName, FormMethod.Post,
                             new { enctype = "multipart/form-data" }))
            {
                helper.AntiForgeryToken();
                await writer.WriteLineAsync("<div class=\"form-horizontal\">");
                await writer.WriteLineAsync("<hr/>");

                writer.WriteLine(helper.ValidationSummary(true, "", new { @class = "text-danger" }));

                helper.DopiszEdytoryDlaPropertiesow(model, writer);
                helper.GenerujPrzyciskiFormularza(akcjaAnuluj).WriteTo(writer, HtmlEncoder.Default);

                await writer.WriteAsync("</div>");
            }
        }

        private static void DopiszEdytoryDlaPropertiesow(
            this IHtmlHelper helper,
            object model,
            TextWriter writer)
        {
            foreach (var prop1 in model.GetType().GetProperties()
                .Select(o => GenerujEditorForProperty(helper, o))
                .Where(o => o != null))
            {
                prop1.WriteTo(writer, HtmlEncoder.Default);
            }
        }

        private static TagBuilder GenerujEditorForProperty(
            this IHtmlHelper helper,
            PropertyInfo prop1)
        {
            var wyswietlac = WyswietlacLabel(prop1.Name, helper.ViewData);

            if (!wyswietlac)
                return null;

            var formGroup = new TagBuilder("div");
            formGroup.AddCssClass("form-group");

            if (Wyswietlac(prop1))
            {
                var l = helper.Label(prop1.Name, helper.DisplayName(prop1.Name), new { @class = "control-label col-md-2" });
                formGroup.InnerHtml.AppendHtml(l);
            }

            var divEditor = new TagBuilder("div");
            divEditor.AddCssClass("col-md-10");
            divEditor.InnerHtml.AppendHtml(helper.Editor(prop1.Name, new { @class = "form-control" }));
            divEditor.InnerHtml.AppendHtml(helper.ValidationMessage(prop1.Name, "", new { @class = "text-danger" }));

            formGroup.InnerHtml.AppendHtml(divEditor);

            return formGroup;

        }

        private static bool Wyswietlac(PropertyInfo prop1)
        {
            var p = prop1.GetCustomAttribute<HiddenInputAttribute>();
            return p == null;
        }

        private static bool WyswietlacLabel(string propertyName, ViewDataDictionary viewData)
        {
            var metadata = viewData.ModelMetadata.Properties.Single(o => o.PropertyName == propertyName);
            return metadata.ShowForEdit;
            //&& (!metadata.IsComplexType || IsSupportedComplexType(metadata))
            //&& !viewData.TemplateInfo.Visited(metadata);
        }
        public static IHtmlContent GenerujPrzyciskiFormularza(
           this IHtmlHelper helper,
           string akcjaAnuluj)
        {
            var tagBuilderFormGroup = new TagBuilder("div");
            tagBuilderFormGroup.AddCssClass("form-group");

            var tagBuilder = new TagBuilder("div");
            tagBuilder.AddCssClass("col-md-offset-2");
            tagBuilder.AddCssClass("col-md-10");

            var przyciskiBuilder = new TagBuilder[2];

            var builderZapisz = PrzygotujBuilderaPrzyciskuZapisz();

            var builderAnuluj = PrzygotujBuilderaPrzyciskuAnuluj(akcjaAnuluj);

            przyciskiBuilder[0] = builderZapisz;
            przyciskiBuilder[1] = builderAnuluj;

            foreach (var b in przyciskiBuilder)
                tagBuilder.InnerHtml.AppendHtml(b);

            tagBuilderFormGroup.InnerHtml.AppendHtml(tagBuilder);

            return tagBuilderFormGroup;
        }
        private static TagBuilder PrzygotujBuilderaPrzyciskuAnuluj(string akcjaAnuluj)
        {
            var builderAnuluj = new TagBuilder("a");
            builderAnuluj.Attributes.Add("href", akcjaAnuluj);
            builderAnuluj.AddCssClass("btn");
            builderAnuluj.AddCssClass("btn-default");
            builderAnuluj.AddCssClass("btn-sm");
            builderAnuluj.InnerHtml.Append("Anuluj");
            return builderAnuluj;
        }

        private static TagBuilder PrzygotujBuilderaPrzyciskuZapisz()
        {
            var builderZapisz = new TagBuilder("input");
            builderZapisz.Attributes.Add("type", "submit");
            builderZapisz.Attributes.Add("value", "Zapisz");
            builderZapisz.Attributes.Add("class", "btn btn-default btn-sm btn-primary");
            return builderZapisz;
        }
    }
}