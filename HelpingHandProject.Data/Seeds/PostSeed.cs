using HelpingHandProject.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpingHandProject.Data.Seeds
{
    public class PostSeed : IEntityTypeConfiguration<Post>
    {
        private readonly int[] _UserIds;
       
        public PostSeed(int[] UserIds)
        {
            _UserIds = UserIds;
           
        }
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasData(
                new Post
                {
                    Id = 1,
                    PostCategory = true,
                    PostText = "Dünya Sağlık Örgütü tarafından pandemi olarak belirtilen Koronavirüs`le mücadele sürecinde hastanemizdeki sağlık personelinin kullanabilmesi için aşağıdaki malzemelere ihtiyacımız bulunmaktadır.",
                    PostDate = new DateTime(2020, 12, 04),
                    UserId = _UserIds[0]

                },
                   new Post
                   {
                       Id = 2,
                       PostCategory = true,
                       PostText = "Koronavirüs salgını nedeni ile azalan hasta sayımıza rağmen günde yaklaşık 150 hasta bakmaktayız. Dezenfektan temin etme konusunda sıkıntı yaşamaktayız.",
                       PostDate = new DateTime(2010, 03, 15),
                       UserId = _UserIds[1]

                   },
                   new Post
                   {
                       Id = 3,
                       PostCategory = true,
                       PostText = "Gelen hastaların ateşini temassız ölçebilmek için alından ölçen ateş ölçerler mevcut ihtiyacı olan hastaneler yollayabilirim.",
                       PostDate = new DateTime(2020, 04, 21),
                       UserId =_UserIds[2] 

                   }, new Post
                   {
                       Id = 4,
                       PostCategory = true,
                       PostText = "Dünya Sağlık Örgütü tarafından pandemi olarak belirtilen Koronavirüs`le mücadele sürecinde hastanemizdeki sağlık personelinin kullanabilmesi için aşağıdaki malzemelere ihtiyacımız bulunmaktadır.",
                       PostDate = new DateTime(2020, 12, 04),
                       UserId = _UserIds[0]

                   },
                   new Post
                   {
                       Id = 5,
                       PostCategory = false,
                       PostText = "İhtiyacı olan 3 öğrenciye burs vereceğim.",
                       PostDate = new DateTime(2010, 03, 15),
                       UserId = _UserIds[1]

                   },
                   new Post
                   {
                       Id = 6,
                       PostCategory = false,
                       PostText = "Geçen seneden kalan ygs kitaplarım duruyor dileyene gönderebilirim.",
                       PostDate = new DateTime(2020, 04, 21),
                       UserId = _UserIds[2]

                   }
                ); 
        }
    }
}
