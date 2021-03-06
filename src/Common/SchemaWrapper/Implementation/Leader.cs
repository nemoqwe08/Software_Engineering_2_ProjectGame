﻿using Common.Schema;

namespace Common.SchemaWrapper
{
    public class Leader: Player
    {
        public override Common.Schema.Player SchemaPlayer
        {
            get
            {
                return new Common.Schema.Player()
                {
                    id = Id,
                    team = Team.Color,
                    type = PlayerType.leader
                };
            }
        }
        public Leader(ulong id, string guid, Team team, uint x = 0, uint y = 0): base(id, guid, team, x, y)
        {

        }

        public Leader(ulong id, string guid,Team team, Location location): base(id, guid, team, location)
        {

        }
    }
}
