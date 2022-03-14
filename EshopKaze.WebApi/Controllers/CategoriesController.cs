using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EshopKaze.Models;
using EshopKaze.Repository;


namespace EshopKaze.WebApi.Controllers
{
    public class CategoriesController : ApiController
    {
        private readonly CategoryRepository categoryRepository;
        public CategoriesController()
        {
            categoryRepository = new CategoryRepository();
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var category = categoryRepository.Get(id);
            if (category == null)
                return NotFound();
            return base.Ok(
                MapCategory(category)
                );
        }

        private CategoryModel MapCategory(Category category)
        {
            return new CategoryModel
                            (
                                category?.Id ?? 0,
                                category?.Name,
                                category?.UserId ?? 0,
                                new UserModel(
                                    category.User.Id,
                                    category.User.Username,
                                    category.User.Password,
                                    category.User.Fullname,
                                    category.User.Role
                                    )
                                );
        }

        [HttpGet]
        public IHttpActionResult Get(string name)
        {
            var category = categoryRepository.Get(name);
            if (category == null)
                return NotFound();
            return Ok(
                MapCategory(category)
            );
        }


        [HttpGet]
        public IHttpActionResult Find(string value)
        {
            var searchValue = value?.ToLower() ?? string.Empty;
            var categories = categoryRepository.Find(
                x => x.Name.ToLower().Contains(searchValue)
                );
           
            return Ok(
                categories.Select
                (
                    x 
                    =>
                    MapCategory(x)

                    ).ToArray());
        }


        [HttpPost]
        public IHttpActionResult Post(CategoryModel categoryModel)
        {

            try
            {
                if (categoryModel == null)
                    return BadRequest();
                var category = new Category(0, categoryModel.Name, categoryModel.UserId);
                category = categoryRepository.Add(category);

                return Ok(
                     MapCategory(category)
               );
            }
            catch (DuplicateWaitObjectException)
            {
                return Conflict();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpPut]
        public IHttpActionResult Put(CategoryModel categoryModel)
        {

            try
            {
                if (categoryModel == null)
                    return BadRequest();
                var category = new Category(categoryModel.Id, categoryModel.Name, categoryModel.UserId);
                category = categoryRepository.Set(category);

                return Ok(
                    MapCategory(category)
                );
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (DuplicateWaitObjectException)
            {
                return Conflict();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {


            var category = categoryRepository.Delete(id);

            return Ok(MapCategory(category));
        }
    }
}
