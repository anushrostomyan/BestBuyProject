using System;
using System.Collections.Generic;
using DataAccessLayer.DataAccess;

namespace BusinessLayer.Entity
{
    public class VideoGame
    {
        public int?    Id { get; private set; }
        public string  Name { get; private set; }
        public string  Developer { get; private set; }
        public string  Genre { get; private set; }
        public string  Platform { get; private set; }
        public string  ColorCategory { get; private set; }
        public string  Model { get; private set; }
        public bool?   Multiplayer { get; private set; }
        public string  ImageAsBase64 { get; private set; }

        enum Games : byte
        {
            VR_Games,
            PC_Games,
            PlayStation4_Games,
            XBoxOne_Games,
            NintendoSwitch_Games,
            Nintendo3DS_Games,
            WiiU_Games,
        }

        public VideoGame()
        {
        }

        
        public VideoGame(int? id, string name, string developer, string genre, string platform,
                             bool multiplayer, string colorcategory, string model, string imageAsBase64)
        {
            Id = id;
            Name = name;
            Developer = developer;
            Genre = genre;
            Platform = platform;
            Multiplayer = multiplayer;
            ColorCategory = colorcategory;
            Model = model;
            ImageAsBase64 = imageAsBase64;
        }

        private VideoGame(Dictionary<string, object> element)
        {
            Id = (int?)element["Id"];
            Name = (string)element["Name"];
            Developer = (string)element["Developer"];
            Genre = (string)element["Genre"];
            Platform = (string)element["Platform"];
            Multiplayer = (bool)element["Multiplayer"];
            ColorCategory = (string)element["Color Category"];
            Model = (string)element["Model"];
            ImageAsBase64 = element["Image"] != null ? Convert.ToBase64String((byte[])element["Image"]) : null;
        }

        public List<VideoGame> GetAllVideoGames()
        {
            try
            {
                DbDataAccess db = new DbDataAccess();
                List<VideoGame> gamesList = new List<VideoGame>();
                List<Dictionary<string, object>> result = db.ExecuteStoredProcedure("GetAllGames", new List<SPParam>());

                if (result!=null&&result.Count!=0)
                {
                    foreach (var item in result)
                    {
                        VideoGame _game = new VideoGame(item);
                        gamesList.Add(_game);
                    }
                }
                return gamesList;
            }

            catch(Exception ex)
            {
                return null;
            }
        }

        public bool? UpdateVideoGameImage(byte[] imagebyte, int videoGameId)
        {
            try
            {

                List<SPParam> param = new List<SPParam>();
                param.Add(new SPParam("ImgBytes", imagebyte));
                param.Add(new SPParam("videoGameId", videoGameId));
                DbDataAccess db = new DbDataAccess();
                List<Dictionary<string, object>> result = db.ExecuteStoredProcedure("UpdateVideoGameImage", param);
                if (result != null && result.Count != 0)
                {
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
