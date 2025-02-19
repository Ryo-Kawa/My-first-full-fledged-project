using Cysharp.Threading.Tasks;
using System.Threading;

public class HomeProcess : ProcessBase<HomeProcessParams>
{
    public HomeProcess(HomeProcessParams processParams) : base(processParams) {}

    public async UniTask WaitForBattleStart(CancellationToken cancellation)
    {
        await View.GetComponent<HomeView>().startBattleButton.OnClickAsync(cancellation);
    }
}
