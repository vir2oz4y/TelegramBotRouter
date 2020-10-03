using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBotRouter.Json;

namespace TelegramBotRouter
{
    static class Keyboard
    {

        public static InlineKeyboardMarkup GetKeyboard(Api api)
        {

            InlineKeyboardMarkup _keyboard = new InlineKeyboardMarkup(new InlineKeyboardButton[][]
                                        {
                                            new []
                                            {
                                                    new InlineKeyboardButton{Text="1",CallbackData="2.2" },
                                                    new InlineKeyboardButton{Text="2",CallbackData="2.2" },
                                            },
                                        }
            );

            for (int i = 0; i < api.messageAfterCommand.Length; i++)
            {
                //_keyboard
            }
            return _keyboard;
        }

    }
}
