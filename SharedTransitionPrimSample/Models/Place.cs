using System;

namespace SharedTransitionPrimSample.Models
{
    public class Place
    {
        public Place(string title, string image, string description)
        {
            Title = title;
            Image = image;
            Description = description;
            Id = Guid.NewGuid().ToString();
        }
        public string Title { get; }
        public string Image { get; }
        public string Description { get; }
        public string Id { get; }
    }
}
