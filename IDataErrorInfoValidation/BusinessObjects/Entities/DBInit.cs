using System.Collections.Generic;
using System.Data.Entity;

namespace BusinessObjects.Entities
{
    internal class DBInit : DropCreateDatabaseAlways<HrContext>
    {
        protected override void Seed(HrContext context)
        {
            base.Seed(context);

        }
    }
}