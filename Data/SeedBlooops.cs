using Blooopy.Models;

namespace Blooopy.Data;

public class SeedBlooops
{
    private Blooop MakeBlooop()
    {
        var comments = new List<Comment>
        {
            new Comment
            {
                Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent aliquam."
            },
            new Comment
            {
                Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque tristique, dolor."
            }
        };

        return new Blooop
        {
            Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur eget commodo risus. Maecenas semper mattis diam, quis ultrices eros posuere ac. Morbi ac lorem sed risus placerat facilisis. Etiam pellentesque facilisis arcu. Morbi ultrices sollicitudin sem, ut feugiat turpis gravida et. Nunc venenatis lacus vel auctor varius.",
            ShareCount = 0,
            Comments = comments
        };
    }
    
    public async Task SeedDatabaseWithBlooops(BlooopContext context, int count)
    {
        var index = 0;

        for (index = 0; index < count; index++)
        {
            var blooop = MakeBlooop();

            context.Blooops?.Add(blooop);
            await context.SaveChangesAsync();
        }
    }
}