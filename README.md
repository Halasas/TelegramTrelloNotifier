# Telegram Trello Notifier

![Preview](/1.png)

This is a backend of Telegram Trello Notifier Bot created by Halasas(aka Lebiafan)

Formulation of the problem
It was necessary to implement a chatbot that would send notifications from Trello to Telegram about changes on the monitored boards. List of required software functionality and properties:

 Functions
* User registration in the chatbot
* Manage notification subscriptions for Trello boards
* Ability to unsubscribe from notifications

Properties
* Extensibility - the software must be suitable for quick modification, adding new functionality
* Stability - the software should correctly process all Telegram user requests and all HTTP requests from Trello
* Optimality - the software should respond to user requests without delays
* Simplicity - software should be available for use without additional knowledge

Stack of technologies
*	С# .Net Framework 4.7.2
*	Telegram Bot API
*	Trello REST API
*	NancyFX - web framework
*	Telegram.Bot - telegram bot framework
*	NewtonSoft.Json - JSON framework
