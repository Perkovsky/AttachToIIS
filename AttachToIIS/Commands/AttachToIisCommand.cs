namespace AttachToIIS.Commands
{
    [Command(PackageIds.AttachToIISCommand)]
    internal sealed class AttachToIisCommand : BaseAttachToIisCommand<AttachToIisCommand>
    {
        public override string ProcessName => "w3wp.exe";
    }
}
