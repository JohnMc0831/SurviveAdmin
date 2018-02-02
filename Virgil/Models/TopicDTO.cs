using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Virgil.Models
{
    public class TopicDTO
    {
        public int id { get; set; }

        public string Title { get; set; }

        public string TitleGerman { get; set; }

        public string TitleSpanish { get; set; }

        public string Summary { get; set; }

        public string SummaryGerman { get; set; }

        public string SummarySpanish { get; set; }

        public string Body { get; set; }

        public string BodyGerman { get; set; }

        public string BodySpanish { get; set; }

        public string BackColor { get; set; }

        public string TextColor { get; set; }

        public int DisplayOrder { get; set; }

        public string TopicIcon { get; set; }

        public TopicDTO(Topic t)
        {
            id = t.id;
            TextColor = t.TextColor;
            Title = t.Title;
            TitleGerman = t.TitleGerman;
            TitleSpanish = t.TitleSpanish;
            Summary = t.Summary;
            SummaryGerman = t.SummaryGerman;
            SummarySpanish = t.SummarySpanish;
            BackColor = t.BackColor;
            DisplayOrder = t.DisplayOrder;
            Body = t.Body;
            BodyGerman = t.BodyGerman;
            BodySpanish = t.BodySpanish;
            TopicIcon = t.TopicIcon;
        }
    }
}