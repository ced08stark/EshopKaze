using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EshopKaze.Repository
{

   
    public class CategoryRepository
    {
        private readonly EshopKazeEntities db;

        public CategoryRepository()
        {
            db = new EshopKazeEntities();
        }

        public Category Get(int id)
        {
            return db.Category.FirstOrDefault(x => x.Id == id);
        }

        public Category Get(string name)
        {
            return db.Category.FirstOrDefault(x => x.Name == name);
        }


        public Category Add(Category category)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));


            var c = Get(category.Name);

            if (c != null)
                throw new DuplicateWaitObjectException($"Category {category.Name} already exist !");

            category = db.Category.Add(category);
            db.SaveChanges();
            return category;
        }

        public Category Set(Category category)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));


            var OldCategory = Get(category.Id);

            if (OldCategory != null)
                throw new KeyNotFoundException($"category not found!");

            var c = new EshopKazeEntities().Category.Find(category.Id);

            if (c != null && c.Id != OldCategory.Id)
                throw new DuplicateWaitObjectException($"Category name {category.Name} already exist !");


            db.Entry(category).State = EntityState.Modified;
            db.SaveChanges();
            return category;
        }

        public Category Delete(int id)
        {
            var category = Get(id);
            db.Category.Remove(category);
            db.SaveChanges();
            return category;
        }


        public IEnumerable<Category> Find(Func<Category, bool> predicate)
        {
            
            return db.Category.Where(predicate).ToArray();
        }

    }


}
