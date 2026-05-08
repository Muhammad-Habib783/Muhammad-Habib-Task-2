using System.Net;
using System.Net.Http;
using System.Web.Http;
using Project2.Models;
using System.Linq;

namespace Project2.Controllers
{
    public class UserController : ApiController
    {
        private UserContext db = new UserContext();

        // GET api/user
        public IQueryable<User> GetUsers()
        {
            return db.Users;
        }

        // GET api/user/5
        public HttpResponseMessage GetUser(int id)
        {
            var user = db.Users.Find(id);
            if (user == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            return Request.CreateResponse(HttpStatusCode.OK, user);
        }

        // POST api/user
        public HttpResponseMessage PostUser(User user)
        {
            if (db.Users.Any(u => u.Email == user.Email))
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Email already exists.");

            db.Users.Add(user);
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, user);
        }

        // PUT api/user/5
        public HttpResponseMessage PutUser(int id, User user)
        {
            var existing = db.Users.Find(id);
            if (existing == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            existing.Name = user.Name;
            existing.Email = user.Email;
            existing.Password = user.Password;
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, existing);
        }

        // DELETE api/user/5
        public HttpResponseMessage DeleteUser(int id)
        {
            var user = db.Users.Find(id);
            if (user == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            db.Users.Remove(user);
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
