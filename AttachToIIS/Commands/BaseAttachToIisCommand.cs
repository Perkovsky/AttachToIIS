using EnvDTE;
using EnvDTE80;

namespace AttachToIIS.Commands
{
    internal abstract class BaseAttachToIisCommand<T> : BaseCommand<T>
        where T : class, new()
    {
        public abstract string ProcessName { get; }

        protected override async Task ExecuteAsync(OleMenuCmdEventArgs e)
        {
            try
            {
                await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();

                var dte = await Package.GetServiceAsync(typeof(DTE)) as DTE2;
                if (dte == null)
                {
                    await VS.MessageBox.ShowErrorAsync("DTE is null.", "Report the bug to the developer.");
                    return;
                }

                var isProcessAttached = false;
                foreach (Process localProcess in dte.Debugger.LocalProcesses)
                {
                    if (!localProcess.Name.EndsWith(ProcessName))
                        continue;

                    localProcess.Attach();
                    isProcessAttached = true;
                }

                if (!isProcessAttached)
                    await VS.MessageBox.ShowWarningAsync("IIS process count not be found.");
            }
            catch (Exception ex)
            {
                await VS.MessageBox.ShowErrorAsync(ex.Message);
            }
        }
    }
}
