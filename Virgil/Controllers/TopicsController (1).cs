using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Virgil.Models;
using Virgil.Repositories;

namespace Virgil.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/Topics")]
    public class TopicsController : ApiController
    {
        private readonly ITopicsRepository db = new TopicsRepository();

        // GET: api/Topics
        [HttpGet]
        [Route("")]
        public List<Topic> GetTopics()
        {
            return db.GetTopics();
        }

        [Route("gettree")]
        [ResponseType(typeof(TopicTree))]
        public TopicTree GetItemTree()
        {
            return new TopicTree(db);
        }


        // GET: api/Topics/5
        [HttpGet]
        [ResponseType(typeof(Topic))]
        [Route("topic/id")]
        public IHttpActionResult GetTopic(int id)
        {
            Topic topic = db.GetTopicById(id);
            if (topic == null)
            {
                return NotFound();
            }
            return Ok(topic);
        }

        // PUT: api/Topics/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTopic(int id, Topic topic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != topic.id)
            {
                return BadRequest();
            }

            db.UpdateTopic(topic);
            return StatusCode(HttpStatusCode.NoContent);
        }


        // POST: api/Topics
        [HttpPost]
        [ResponseType(typeof(Topic))]
        public IHttpActionResult PostTopic(Topic topic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AddTopic(topic);
            return CreatedAtRoute("DefaultApi", new { id = topic.id }, topic);
        }

        // DELETE: api/Topics/5
        [ResponseType(typeof(Topic))]
        public IHttpActionResult DeleteTopic(int id)
        {
            Topic topic = db.GetTopicById(id);
            if (topic == null)
            {
                return NotFound();
            }

            db.RemoveTopic(topic);
            return Ok(topic);
        }

        private bool TopicExists(int id)
        {
            return db.GetTopics().Any(t => t.id == id);
        }
    }
}