using BlazorServerAppDemo.Models;
using BlazorServerAppDemo.Components;
using BootstrapBlazor.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace BlazorServerAppDemo.Pages
{
    public partial class Index
    {
        protected async override Task OnInitializedAsync()
        {
            base.OnInitialized();
        }

        [Parameter]
        public AuthCode? ParentValue {get; set;}


        private DialogOption? Option {get; set;}

        /// 显示对话框
        private async Task ShowDialog() 
        {
            ParentValue = new() { RequestCode = "a3Dr3g5z" };

            Option = new DialogOption()
            {
                Title = "生成授权码",
                Size = Size.Large,
                BodyContext = ParentValue,
                BodyTemplate =  BootstrapDynamicComponent.CreateComponent<TestComponent>(new Dictionary<string, object?>
                {
                    [nameof(TestComponent.Value)] = ParentValue,
                    [nameof(TestComponent.ValueChanged)] = EventCallback.Factory.Create<AuthCode?>(this, v => ParentValue = v)
                }).Render(),
                FooterTemplate = BootstrapDynamicComponent.CreateComponent<Button>(new Dictionary<string, object?>
                {
                    [nameof(Button.Text)] = "生成授权码",
                    [nameof(Button.OnClick)] = EventCallback.Factory.Create<MouseEventArgs>(this, async () => {
                        ParentValue.ResultCode = "3F4H5G";

                        // Question: 生成授权码后，文本框不会立即刷新，尝试使用以下方法但是没有用
                        InvokeAsync(StateHasChanged);
                        Option.BodyContext  = ParentValue;
                    })
                }).Render()
            };

            await DialogService.Show(Option);
        }

        [Inject]
        private DialogService? DialogService { get; set; }

        [Inject]
        private MessageService? MsgeService { get; set; }
    }
}
