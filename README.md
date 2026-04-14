<h1 align="center">🛰️ FreelancerAdminAudit 🛰️</h1>

<p align="center">
  <img src="https://shields.dvurechensky.pro/badge/Platform-Windows-0078D6?style=for-the-badge&logo=windows&logoColor=white" />
  <img src="https://shields.dvurechensky.pro/badge/Language-C%23-239120?style=for-the-badge&logo=csharp&logoColor=white" />
  <img src="https://shields.dvurechensky.pro/badge/Protocol-TCP-FF6F00?style=for-the-badge" />
  <img src="https://shields.dvurechensky.pro/badge/Purpose-Security%20Research-D32F2F?style=for-the-badge" />
  <img src="https://shields.dvurechensky.pro/badge/Game-Freelancer%202003-5E35B1?style=for-the-badge" />
  <img src="https://shields.dvurechensky.pro/badge/Status-Research-00C853?style=for-the-badge" />
</p>

<div align="center" style="margin: 20px 0; padding: 10px; background: #1c1917; border-radius: 10px;">
  <strong>🌐 Language: </strong>
  
  <a href="./README.ru.md" style="color: #F5F752; margin: 0 10px;">
    🇷🇺 Russian
  </a>
  | 
  <span style="color: #0891b2; margin: 0 10px;">
    ✅ 🇺🇸 English (current)
  </span>
</div>

---

> [!NOTE]
> This project is part of the **Lizerium** ecosystem and belongs to the following direction:
>
> - [`Lizerium.Tools.Structs`](https://github.com/Lizerium/Lizerium.Tools.Structs)
>
> If you are looking for related engineering and supporting tools, start there.

# Description

---

## ⚠️ Important

> [!WARNING]
> This project is published **strictly for research and educational purposes**.  
> Its goal is to demonstrate architectural and configuration weaknesses in remote administrative interfaces of **Freelancer (2003)** servers.

> [!IMPORTANT]
> During the research, a remote administrative access issue was identified on a public community server.  
> The issue **was responsibly disclosed to the administrators**, and fixes were applied.  
> For example:
>
> - [Freelancer: Sirius Revival](https://fl-sr.eu/)
> - [Freelancer: Rebirth](https://freelancerothe.ucoz.ru/)

> [!CAUTION]
> If similar configurations are still used on other servers, they may be vulnerable to the same risks.

---

## ❓ What is this

**FreelancerAdminAudit** is a simple TCP client designed to analyze and test remote administrative consoles of **Freelancer (2003)** servers.

With it, you can:

- connect to a server’s administrative TCP panel
- authenticate using a password
- send commands to the server console
- evaluate how exposed and insecure remote access is
- reproduce configuration and architectural weaknesses

---

## 🔥 Why this project exists

While researching legacy server implementations for **Freelancer (2003)**, I noticed that some servers use **remote admin panels** with extremely weak protection:

- open TCP port
- password-based authentication only
- no additional restrictions
- lack of proper network isolation
- overly powerful administrative commands

During testing, I confirmed that under certain conditions, it is possible to access the server’s administrative interface.

This is not a “magic exploit”, but a demonstration of how dangerous **misconfigured legacy systems** can be.

---

## 💣 What can be accessed through such panels

Depending on server configuration and installed plugins, a remote console may allow:

- reading player information
- accessing character data
- modifying money / reputation / cargo
- kicking / banning players
- executing administrative actions
- managing plugins
- retrieving internal server data

The issue is not a “clever hack”, but the fact that some servers historically exposed **powerful admin capabilities with weak protection**.

---

## 🧪 What this client does

The application:

- connects to a specified IP and port
- waits for authentication prompt
- sends password
- after successful authentication allows manual command execution
- displays server responses in the console

---

## 🛠️ Technologies

- **C#**
- **.NET**
- **TCP / Socket communication**
- **ASCII protocol interaction**
- **Legacy game server protocol testing**

---

## 🚀 Example

```text
[+] Connection established.
[<] Welcome to FLHack, please authenticate
[>] Sent login: pass test
[<] OK

Enter command: help
[>] Sent command: help
[<] Server response:
[version]
4.0.0-Dormammu plugin
[commands]
getcash <charname>
setcash <charname> <amount>
...
OK
```

---

## 📢 Responsible Disclosure Proof

### Freelancer: Sirius Revival

![alt text](media/Freelancer_Sirius.png)
