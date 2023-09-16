using System.Threading.Tasks;

public partial class DepsFromResolver : InitializableNode
{
    private DerivedClass _derivedClass;

    // Perhaps Inject gets called first to make sure everything has dependencies.
    public void Inject(ServiceResolver resolver) {
        _derivedClass = resolver.Resolve<DerivedClass>();
    }

    protected override Task InitializeDependencies()
    {
        // What if DerivedClass needs to be initializable now?
        return Task.CompletedTask;
    }

    protected override Task OnInitialize()
    {
        return Task.CompletedTask;
    }
}
