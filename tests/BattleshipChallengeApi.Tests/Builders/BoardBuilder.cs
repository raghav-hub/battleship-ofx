using BattleshipChallenge.Core.Models;
using BattleshipChallengeApi.UnitTests;
using System;
using System.Collections.Generic;

namespace BattleshipChallengeApi.IntegrationTests.Builders
{
    public class BoardBuilder
    {
        public BoardBuilder()
        {
            WithId(RandomBuilder.NextGuid());
            WithName(RandomBuilder.NextString());
        }

        private Action<Board> _buildSetup;

        public Board Build()
        {
            var board = new Board();
            _buildSetup(board);
            return board;
        }

        public BoardBuilder WithId(Guid boardId)
        {
            _buildSetup += b => b.Id = boardId;
            return this;
        }

        public BoardBuilder WithName(string name)
        {
            _buildSetup += b => b.Name = name;
            return this;
        }

        public BoardBuilder WithPlayerShips(List<PlayerShips> playerShips)
        {
            _buildSetup += b => b.PlayerShips = playerShips;
            return this;
        }

        public BoardBuilder WithOccupiedCoordinates(List<Coordinates> occupiedCoordinates)
        {
            _buildSetup += b => b.OccupiedCoordinates = occupiedCoordinates;
            return this;
        }
    }
}