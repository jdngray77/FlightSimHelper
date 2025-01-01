using Spectre.Console;

namespace MSFSHelper.NewViews;

public class SimBriefView : View
{
    object simbriefData = testmain.test();
    
    public override async Task Render()
    {
        Layout layout = new Layout()
            .SplitColumns(
            new Layout("Left"),
            new Layout("Right")
                .SplitRows(
                    new Layout("Top"),
                    new Layout("Bottom")));
        
        
    }

}