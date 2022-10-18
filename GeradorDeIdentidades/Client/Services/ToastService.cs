using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace GeradorDeIdentidades.Client.Services
{
    public sealed class ToastService
    {
        private readonly IJSRuntime _jsRuntime;

        public ToastService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public ValueTask Show(string text)
        {
            return _jsRuntime.InvokeVoidAsync("toastr.info", text);
        }
        public ValueTask ShowError(string text)
        {
            return _jsRuntime.InvokeVoidAsync("toastr.error", text);
        }
    }
}
