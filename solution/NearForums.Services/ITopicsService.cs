﻿using System;
using System.Collections.Generic;
using NearForums.Validation;

namespace NearForums.Services
{
	public interface ITopicsService
	{
		/// <summary>
		/// Adds a visit to a topic (asynchronously)
		/// </summary>
		/// <param name="topicId"></param>
		void AddVisit(int topicId);
		/// <summary>
		/// Closes a topic to disallow further replies.
		/// </summary>
        void Close(int id, Guid userId, string ip);
		/// <summary>
		/// Creates a topic
		/// </summary>
		/// <exception cref="ValidationException"></exception>
		/// <param name="user">User editing the topic</param>
		void Create(Topic topic, string ip, User user);
		/// <summary>
		/// Deletes (inactive) a user from the application
		/// </summary>
        void Delete(int id, Guid userId, string ip);
		/// <summary>
		/// Edits a topic
		/// </summary>
		/// <exception cref="ValidationException"></exception>
		/// <param name="user">User editing the topic</param>
		void Edit(Topic topic, string ip, User user);
		/// <summary>
		/// Gets a topic by id, validating that the shortName matches
		/// </summary>
		Topic Get(int id, string shortName);
		/// <summary>
		/// Gets a topic by id
		/// </summary>
		/// <param name="topicId"></param>
		/// <returns></returns>
		Topic Get(int topicId);
		/// <summary>
		/// Gets a list of topics of a forum ordered by views
		/// </summary>
		List<Topic> GetByForum(int forumId, int startIndex, int length, UserRole? role);
		/// <summary>
		/// Gets the topics tagged in a certain forum
		/// </summary>
		/// <returns></returns>
		List<Topic> GetByTag(string tag, int forumId, UserRole? role);
		/// <summary>
		/// Gets a list of topics posted by the user
		/// </summary>
		/// <param name="role">Role of the user requesting the page</param>
        List<Topic> GetByUser(Guid userId, UserRole? role);
		List<Topic> GetLatest();
		List<Topic> GetLatest(int forumId, int startIndex, int length, UserRole? role);
		/// <summary>
		/// Gets a list of topics with the messages posted by the user
		/// </summary>
        List<Topic> GetTopicsAndMessagesByUser(Guid userId);
		/// <summary>
		/// Get a topic containing an specific amount of messages starting from firstMsg
		/// </summary>
		/// <param name="firstMsg">Zero-based index of the message</param>
		Topic GetWithMessages(int topicId, int firstMsg, int amount);
		/// <summary>
		/// Gets a topic with its latest messages in descending order.
		/// </summary>
		/// <param name="id"></param>
		/// <param name="name"></param>
		/// <returns></returns>
		Topic GetWithMessagesLatest(int id, string name);
		/// <summary>
		/// Gets a list of unanswered topics from all forums
		/// </summary>
		/// <param name="firstMsg">Zero-based index of the topic</param>
		/// <param name="amount">Number of topics to return</param>
		/// <returns></returns>
		List<Topic> GetAllUnanswered(int firstMsg, int amount);
		/// <summary>
		/// Gets total count of unanswered topics
		/// </summary>
		/// <returns></returns>
		int GetUnansweredTopicCount();
		/// <summary>
		/// Gets a list of unanswered topics
		/// </summary>
		/// <returns></returns>
		List<Topic> GetUnanswered(int forumId, UserRole? role);
		void LoadRelatedTopics(Topic topic, int amount);
		/// <summary>
		/// Moves a topic from a forum to another.
		/// </summary>
        Topic Move(int id, int forumId, Guid userId, string ip);
		/// <summary>
		/// Opens a topic to allow replies.
		/// </summary>
        void Open(int id, Guid userId, string ip);
		/// <summary>
		/// Flag an topic as inappropriate
		/// </summary>
		/// <param name="topicId">Topic Id</param>
		/// <param name="ip">Flagger's Ip</param>
		/// <returns>If successful.</returns>
		bool Flag(int topicId, string ip);
	}
}
