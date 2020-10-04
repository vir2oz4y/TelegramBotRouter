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

            double countCell = 4;
            double countRow = Math.Ceiling(api.Directories.Count / countCell);
            InlineKeyboardMarkup _keyboard;

            InlineKeyboardButton[][] button = new InlineKeyboardButton[(int)countRow][];


            for (int i = 0; i < countRow; i++)
            {
                Array.Resize(ref button[i], (int)countCell);

                if (i == countRow - 1 )
                {
                    countCell = api.Directories.Count - (countRow - 1) * countCell;
                    Array.Resize(ref button[i], (int)countCell);
                }

                for (int j = 0; j < countCell; j++)
                {
                    
                    button[i][j] = new InlineKeyboardButton { Text = api.Directories[i*(int)countCell+j].directory, CallbackData = api.Directories[i * (int)countCell + j].directory, };
                }
            }

            _keyboard = new InlineKeyboardMarkup(button);
            return _keyboard;
        }

    }
}
