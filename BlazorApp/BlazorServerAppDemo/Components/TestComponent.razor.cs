using BlazorServerAppDemo.Models;
using BootstrapBlazor.Components;
using Microsoft.AspNetCore.Components;

namespace BlazorServerAppDemo.Components
{
    public partial class TestComponent
    {
        [Parameter]
        public AuthCode? Value { get; set; }

        [Parameter]
        public EventCallback<AuthCode>? ValueChanged { get; set; }
    }
}
