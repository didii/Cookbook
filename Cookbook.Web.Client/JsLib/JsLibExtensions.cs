using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor;
using Microsoft.JSInterop;

namespace Cookbook.Web.Client.JsLib {
    public static class JsLibExtensions {
        public static Task Focus(this ElementRef elementRef) {
            return JSRuntime.Current.InvokeAsync<object>("jsLib.focusElement", elementRef);
        }

        public static Task Hide(this ElementRef elementRef) {
            return JSRuntime.Current.InvokeAsync<object>("jsLib.hideElement", elementRef);
        }

        public static Task Show(this ElementRef elementRef) {
            return JSRuntime.Current.InvokeAsync<object>("jsLib.showElement", elementRef);
        }
    }
}
