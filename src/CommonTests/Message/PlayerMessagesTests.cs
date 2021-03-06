﻿using Common.Message;
using Common.Schema;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonTests.Message
{
    [TestClass]
    public class PlayerMessagesTests
    {
        [TestMethod]
        public void ConfirmGameRegistrationTest()
        {
            ConfirmJoiningGame message = new ConfirmJoiningGame();
    
            message.playerId = 3;

            message.gameId = 1;

            message.privateGuid = "c094cab7-da7b-457f-89e5-a5c51756035f";

            message.PlayerDefinition = new Player() { id = 2 };

            string xml = XmlMessageConverter.ToXml(message);
            ConfirmJoiningGame result = (ConfirmJoiningGame)XmlMessageConverter.ToObject(xml);

            Assert.AreEqual((ulong)3, result.playerId);
            Assert.AreEqual((ulong)1, result.gameId);
            Assert.AreEqual("c094cab7-da7b-457f-89e5-a5c51756035f", result.privateGuid);
            Assert.AreEqual((ulong)2, result.PlayerDefinition.id);
        }

        [TestMethod]
        public void DataTest()
        {
            Data message = new Data();

            message.playerId = 0;

            message.gameFinished = true;

            GoalField[] goalFieldsTab = new GoalField[3];
            goalFieldsTab[0] = new GoalField() { team = TeamColour.red };
            message.GoalFields = goalFieldsTab;

            Piece[] pieceTab = new Piece[2];
            pieceTab[0] = new Piece() { playerId = 2 , playerIdSpecified = true};
            message.Pieces = pieceTab;

            message.PlayerLocation = new Location() { x = 3 };

            TaskField[] taskFieldTab = new TaskField[3];
            taskFieldTab[0]= new TaskField() { x = 3 };
            message.TaskFields = taskFieldTab;

            string xml = XmlMessageConverter.ToXml(message);
            Data result = (Data)XmlMessageConverter.ToObject(xml);

            Assert.AreEqual((ulong)0, result.playerId);
            Assert.AreEqual(true, result.gameFinished);
            Assert.AreEqual(TeamColour.red, result.GoalFields[0].team);
            Assert.AreEqual((ulong)2, result.Pieces[0].playerId);
            Assert.AreEqual((uint)3, result.PlayerLocation.x);
            Assert.AreEqual((ulong)3, result.TaskFields[0].x);
        }

        [TestMethod]
        public void GameTest()
        {
            Game message = new Game();

            message.playerId = 0;

            message.PlayerLocation = new Location() { x = 3 };

            message.Board = new GameBoard() { width = 10 };

            Player[] playerTab = new Player[3];
            playerTab[0] = new Player() { id = 1 };

            message.Players = playerTab;

            string xml = XmlMessageConverter.ToXml(message);
            Game result = (Game)XmlMessageConverter.ToObject(xml);

            Assert.AreEqual((ulong)0, result.playerId);
            Assert.AreEqual((uint)3, result.PlayerLocation.x);
            Assert.AreEqual((uint)10, result.Board.width);
            Assert.AreEqual((ulong)1, result.Players[0].id);
        }

        

       [TestMethod]
        public void RejectKnowledgeExchangeTest()
        {
            RejectKnowledgeExchange message = new RejectKnowledgeExchange();

            message.permanent = false;

            string xml = XmlMessageConverter.ToXml(message);
            RejectKnowledgeExchange result = (RejectKnowledgeExchange)XmlMessageConverter.ToObject(xml);

            Assert.AreEqual(false, result.permanent);
        }

        [TestMethod]
        public void PlayerTest()
        {
           Player message = new Player();

            message.id = 0;
            message.team = TeamColour.blue;
            message.type = PlayerType.leader;

            string xml = XmlMessageConverter.ToXml(message);
            Player result = (Player)XmlMessageConverter.ToObject(xml);

            Assert.AreEqual((ulong)0, result.id);
            Assert.AreEqual(TeamColour.blue, result.team);
            Assert.AreEqual(PlayerType.leader, result.type);
        }

        [TestMethod]
        public void PlayerMessageTest()
        {
            PlayerMessage message = new PlayerMessage();

            message.playerId = 1;


            string xml = XmlMessageConverter.ToXml(message);
            PlayerMessage result = (PlayerMessage)XmlMessageConverter.ToObject(xml);

            Assert.AreEqual((ulong)1, result.playerId);

        }

    }
}
