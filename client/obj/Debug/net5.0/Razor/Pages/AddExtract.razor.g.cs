#pragma checksum "C:\src\Radzen\SDE5\client\Pages\AddExtract.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2056d39960a5ec5b66e3ac9c85f8bc8be3059e38"
// <auto-generated/>
#pragma warning disable 1591
namespace Sde5.Client.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\src\Radzen\SDE5\client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\src\Radzen\SDE5\client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\src\Radzen\SDE5\client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\src\Radzen\SDE5\client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\src\Radzen\SDE5\client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\src\Radzen\SDE5\client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\src\Radzen\SDE5\client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\src\Radzen\SDE5\client\_Imports.razor"
using Sde5.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\src\Radzen\SDE5\client\_Imports.razor"
using Sde5.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\src\Radzen\SDE5\client\Pages\AddExtract.razor"
using Radzen;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\src\Radzen\SDE5\client\Pages\AddExtract.razor"
using Radzen.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\src\Radzen\SDE5\client\Pages\AddExtract.razor"
using Sde5.Models.Sde;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(MainLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/add-extract")]
    public partial class AddExtract : Sde5.Pages.AddExtractComponent
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Radzen.Blazor.RadzenContent>(0);
            __builder.AddAttribute(1, "Container", "main");
            __builder.AddAttribute(2, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenElement(3, "div");
                __builder2.AddAttribute(4, "class", "row");
                __builder2.OpenElement(5, "div");
                __builder2.AddAttribute(6, "class", "col-md-12");
                __builder2.OpenComponent<Radzen.Blazor.RadzenTemplateForm<Sde5.Models.Sde.Extract>>(7);
                __builder2.AddAttribute(8, "Data", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Sde5.Models.Sde.Extract>(
#nullable restore
#line 12 "C:\src\Radzen\SDE5\client\Pages\AddExtract.razor"
                                   extract

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(9, "Visible", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 12 "C:\src\Radzen\SDE5\client\Pages\AddExtract.razor"
                                                       extract != null

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(10, "Submit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Sde5.Models.Sde.Extract>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Sde5.Models.Sde.Extract>(this, 
#nullable restore
#line 12 "C:\src\Radzen\SDE5\client\Pages\AddExtract.razor"
                                                                                                                  Form0Submit

#line default
#line hidden
#nullable disable
                )));
                __builder2.AddAttribute(11, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder3) => {
                    __builder3.OpenElement(12, "div");
                    __builder3.AddAttribute(13, "style", "margin-bottom: 1rem");
                    __builder3.AddAttribute(14, "class", "row");
                    __builder3.OpenElement(15, "div");
                    __builder3.AddAttribute(16, "class", "col-md-3");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenLabel>(17);
                    __builder3.AddAttribute(18, "Text", "Name");
                    __builder3.AddAttribute(19, "Component", "Name");
                    __builder3.AddAttribute(20, "style", "width: 100%");
                    __builder3.CloseComponent();
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(21, "\n              ");
                    __builder3.OpenElement(22, "div");
                    __builder3.AddAttribute(23, "class", "col-md-9");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenTextBox>(24);
                    __builder3.AddAttribute(25, "MaxLength", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int64?>(
#nullable restore
#line 20 "C:\src\Radzen\SDE5\client\Pages\AddExtract.razor"
                                          100

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(26, "style", "display: block; width: 100%");
                    __builder3.AddAttribute(27, "Name", "Name");
                    __builder3.AddAttribute(28, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 20 "C:\src\Radzen\SDE5\client\Pages\AddExtract.razor"
                                                                                                  extract.Name

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(29, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => extract.Name = __value, extract.Name))));
                    __builder3.AddAttribute(30, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => extract.Name));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(31, "\n                ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenRequiredValidator>(32);
                    __builder3.AddAttribute(33, "Component", "Name");
                    __builder3.AddAttribute(34, "Text", "Name is required");
                    __builder3.AddAttribute(35, "style", "position: absolute");
                    __builder3.CloseComponent();
                    __builder3.CloseElement();
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(36, "\n            ");
                    __builder3.OpenElement(37, "div");
                    __builder3.AddAttribute(38, "style", "margin-bottom: 1rem");
                    __builder3.AddAttribute(39, "class", "row");
                    __builder3.OpenElement(40, "div");
                    __builder3.AddAttribute(41, "class", "col-md-3");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenLabel>(42);
                    __builder3.AddAttribute(43, "Text", "Description");
                    __builder3.AddAttribute(44, "Component", "Description");
                    __builder3.AddAttribute(45, "style", "width: 100%");
                    __builder3.CloseComponent();
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(46, "\n              ");
                    __builder3.OpenElement(47, "div");
                    __builder3.AddAttribute(48, "class", "col-md-9");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenTextBox>(49);
                    __builder3.AddAttribute(50, "MaxLength", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int64?>(
#nullable restore
#line 32 "C:\src\Radzen\SDE5\client\Pages\AddExtract.razor"
                                          100

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(51, "style", "display: block; width: 100%");
                    __builder3.AddAttribute(52, "Name", "Description");
                    __builder3.AddAttribute(53, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 32 "C:\src\Radzen\SDE5\client\Pages\AddExtract.razor"
                                                                                                  extract.Description

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(54, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => extract.Description = __value, extract.Description))));
                    __builder3.AddAttribute(55, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => extract.Description));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(56, "\n                ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenRequiredValidator>(57);
                    __builder3.AddAttribute(58, "Component", "Description");
                    __builder3.AddAttribute(59, "Text", "Description is required");
                    __builder3.AddAttribute(60, "style", "position: absolute");
                    __builder3.CloseComponent();
                    __builder3.CloseElement();
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(61, "\n            ");
                    __builder3.OpenElement(62, "div");
                    __builder3.AddAttribute(63, "style", "margin-bottom: 1rem");
                    __builder3.AddAttribute(64, "class", "row");
                    __builder3.OpenElement(65, "div");
                    __builder3.AddAttribute(66, "class", "col-md-3");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenLabel>(67);
                    __builder3.AddAttribute(68, "Text", "External Code");
                    __builder3.AddAttribute(69, "Component", "ExternalCode");
                    __builder3.AddAttribute(70, "style", "width: 100%");
                    __builder3.CloseComponent();
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(71, "\n              ");
                    __builder3.OpenElement(72, "div");
                    __builder3.AddAttribute(73, "class", "col-md-9");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenTextBox>(74);
                    __builder3.AddAttribute(75, "MaxLength", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int64?>(
#nullable restore
#line 44 "C:\src\Radzen\SDE5\client\Pages\AddExtract.razor"
                                          100

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(76, "style", "display: block; width: 100%");
                    __builder3.AddAttribute(77, "Name", "ExternalCode");
                    __builder3.AddAttribute(78, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 44 "C:\src\Radzen\SDE5\client\Pages\AddExtract.razor"
                                                                                                  extract.ExternalCode

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(79, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => extract.ExternalCode = __value, extract.ExternalCode))));
                    __builder3.AddAttribute(80, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => extract.ExternalCode));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(81, "\n                ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenRequiredValidator>(82);
                    __builder3.AddAttribute(83, "Component", "ExternalCode");
                    __builder3.AddAttribute(84, "Text", "ExternalCode is required");
                    __builder3.AddAttribute(85, "style", "position: absolute");
                    __builder3.CloseComponent();
                    __builder3.CloseElement();
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(86, "\n            ");
                    __builder3.OpenElement(87, "div");
                    __builder3.AddAttribute(88, "style", "margin-bottom: 1rem");
                    __builder3.AddAttribute(89, "class", "row");
                    __builder3.OpenElement(90, "div");
                    __builder3.AddAttribute(91, "class", "col-md-3");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenLabel>(92);
                    __builder3.AddAttribute(93, "Text", "Is Active");
                    __builder3.AddAttribute(94, "Component", "IsActive");
                    __builder3.AddAttribute(95, "style", "width: 100%");
                    __builder3.CloseComponent();
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(96, "\n              ");
                    __builder3.OpenElement(97, "div");
                    __builder3.AddAttribute(98, "class", "col-md-9");
                    __Blazor.Sde5.Client.Pages.AddExtract.TypeInference.CreateRadzenCheckBox_0(__builder3, 99, 100, "IsActive", 101, 
#nullable restore
#line 56 "C:\src\Radzen\SDE5\client\Pages\AddExtract.razor"
                                               extract.IsActive

#line default
#line hidden
#nullable disable
                    , 102, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => extract.IsActive = __value, extract.IsActive)), 103, () => extract.IsActive);
                    __builder3.CloseElement();
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(104, "\n            ");
                    __builder3.OpenElement(105, "div");
                    __builder3.AddAttribute(106, "class", "row");
                    __builder3.OpenElement(107, "div");
                    __builder3.AddAttribute(108, "class", "col offset-sm-3");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenButton>(109);
                    __builder3.AddAttribute(110, "ButtonType", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.ButtonType>(
#nullable restore
#line 62 "C:\src\Radzen\SDE5\client\Pages\AddExtract.razor"
                                          ButtonType.Submit

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(111, "Icon", "save");
                    __builder3.AddAttribute(112, "Text", "Save");
                    __builder3.AddAttribute(113, "ButtonStyle", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.ButtonStyle>(
#nullable restore
#line 62 "C:\src\Radzen\SDE5\client\Pages\AddExtract.razor"
                                                                                                  ButtonStyle.Primary

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(114, "\n                ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenButton>(115);
                    __builder3.AddAttribute(116, "ButtonStyle", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.ButtonStyle>(
#nullable restore
#line 64 "C:\src\Radzen\SDE5\client\Pages\AddExtract.razor"
                                           ButtonStyle.Light

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(117, "style", "margin-left: 1rem");
                    __builder3.AddAttribute(118, "Text", "Cancel");
                    __builder3.AddAttribute(119, "Click", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 64 "C:\src\Radzen\SDE5\client\Pages\AddExtract.razor"
                                                                                                              Button2Click

#line default
#line hidden
#nullable disable
                    )));
                    __builder3.CloseComponent();
                    __builder3.CloseElement();
                    __builder3.CloseElement();
                }
                ));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.CloseElement();
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
    }
}
namespace __Blazor.Sde5.Client.Pages.AddExtract
{
    #line hidden
    internal static class TypeInference
    {
        public static void CreateRadzenCheckBox_0<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.String __arg0, int __seq1, TValue __arg1, int __seq2, global::Microsoft.AspNetCore.Components.EventCallback<TValue> __arg2, int __seq3, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg3)
        {
        __builder.OpenComponent<global::Radzen.Blazor.RadzenCheckBox<TValue>>(seq);
        __builder.AddAttribute(__seq0, "Name", __arg0);
        __builder.AddAttribute(__seq1, "Value", __arg1);
        __builder.AddAttribute(__seq2, "ValueChanged", __arg2);
        __builder.AddAttribute(__seq3, "ValueExpression", __arg3);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591
