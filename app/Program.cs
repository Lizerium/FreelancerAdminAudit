/*
 * Author: Nikolay Dvurechensky
 * Site: https://dvurechensky.pro/
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 01 мая 2026 06:52:19
 * Version: 1.0.36
 */

using System.Net.Sockets;
using System.Text;

class FLHookClient
{
    static void Main()
    {
        /*
        REBIRTH

        [+] Подключение установлено.
        [<] Welcome to FLHack, please authenticate
        [>] Отправлен логин: pass test
        [<] OK

        Введите команду: help
        [>] Отправлена команда: help
        [<] Ответ сервера:
        [version]
        4.0.0-Dormammu plugin
        [commands]
        getcash <charname>
        setcash <charname> <amount>
        setcashsec <charname> <oldmoney> <amount>
        addcash <charname> <amount>
        addcashsec <charname> <oldmoney> <amount>
        kick <charname> <reason>
        ban <charname>
        unban <charname>
        kickban <charname> <reason>
        beam <charname> <basename>
        kill <charname>
        resetrep <charname>
        setrep <charname> <repgroup> <value>
        getrep <charname> <repgroup>
        readcharfile <charname>
        writecharfile <charname> <data>
        enumcargo <charname>
        addcargo <charname> <good> <count> <mission>
        removecargo <charname> <id> <count>
        rename <oldcharname> <newcharname>
        deletechar <charname>
        msg <charname> <text>
        msgs <systemname> <text>
        msgu <text>
        fmsg <charname> <xmltext>
        fmsgs <systemname> <xmltext>
        fmsgu <xmltext>
        enumcargo <charname>
        addcargo <charname> <good> <count> <mission>
        removecargo <charname> <id> <count>
        getgroupmembers <charname>
        getbasestatus <basename>
        getclientid <charname>
        getplayerinfo <charname>
        getplayers
        xgetplayerinfo <charname>
        xgetplayers
        getplayerids
        help
        getaccountdirname <charname>
        getcharfilename <charname>
        isonserver <charname>
        isloggedin <charname>
        serverinfo
        moneyfixlist
        savechar <charname>
        setadmin <charname> <rights>
        getadmin <charname>
        deladmin <charname>
        getreservedslot <charname>
        setreservedslot <charname> <value>
        loadplugins
        loadplugin <plugin filename>
        listplugins
        unloadplugin <plugin shortname>
        pauseplugin <plugin shortname>
        unpauseplugin <plugin shortname>
        rehash
        prlog <on><off> <--- ????????????? ?????? ????????? ??? ????????????
        actest <--- ???????? ????????? ???????
        attest <--- ???????????? ??? DLL, ????????????? ? ??????????
        startmission
        endmission
        enumeqlist <charname>
        getclientid <charname>
        move x, y, z
        pull <charname>
        chase <charname>
        smiteall [die]
        testbot <system> <testtime>
        authchar <charname>
        reloadbans
        setaccmovecode <charname> <code>
        rotatelogs
        privatemsg|pm <charname> <message>
        showtags
        addtag <tag> <password>
        droptag <tag> <password>
        tempban <charname>
        OK
         */
        string serverIp = "37.230.137.109";
        int port = 1919; // Порт
        string password = "test"; // Пароль для аутентификации

        try
        {
            using var client = new TcpClient(serverIp, port);
            using var stream = client.GetStream();
            using var writer = new StreamWriter(stream, Encoding.ASCII)
            {
                AutoFlush = true,
                NewLine = "\r\n" // CRLF — важно!
            };
            using var reader = new StreamReader(stream, Encoding.ASCII);

            Console.WriteLine("[+] Подключение установлено.");

            // Читаем приветствие сервера
            string welcome;
            while ((welcome = reader.ReadLine()) != null)
            {
                Console.WriteLine("[<] " + welcome);
                if (welcome.Contains("authenticate")) break; // ждем приглашение
            }

            Thread.Sleep(500); // пауза перед логином

            // Аутентификация
            writer.WriteLine("pass " + password);
            Console.WriteLine("[>] Отправлен логин: pass " + password);

            // Читаем ответ на логин
            string loginResp;
            while ((loginResp = reader.ReadLine()) != null)
            {
                Console.WriteLine("[<] " + loginResp);
                if (loginResp.Contains("OK") || loginResp.Contains("ERR")) break;
            }

            // Цикл для ввода и отправки команд
            while (true)
            {
                Console.Write("\nВведите команду: ");
                string command = Console.ReadLine();

                // Если введена команда "exit", закрываем соединение
                if (command.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("[>] Завершение работы.");
                    break;
                }

                // Отправляем команду
                writer.WriteLine(command);
                Console.WriteLine("[>] Отправлена команда: " + command);

                // Читаем ответ
                string response;
                Console.WriteLine("[<] Ответ сервера:");
                while ((response = reader.ReadLine()) != null)
                {
                    Console.WriteLine(response);
                    if (response.Contains("OK") || response.Contains("ERR")) break;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("[!] Ошибка: " + ex.Message);
        }
    }
}
