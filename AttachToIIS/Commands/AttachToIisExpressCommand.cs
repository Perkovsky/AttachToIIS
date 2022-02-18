namespace AttachToIIS.Commands
{
    [Command(PackageIds.AttachToIISExpressCommand)]
    internal sealed class AttachToIisExpressCommand : BaseAttachToIisCommand<AttachToIisExpressCommand>
    {
        public override string ProcessName => "iisexpress.exe";
    }
}
