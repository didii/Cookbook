using Microsoft.JSInterop;

namespace Cookbook.Web.Client.Helpers {
    public static class JsonConvertExtensions {
        public static string ToJson(this object obj) {
            return Json.Serialize(obj);
        }
    }
}