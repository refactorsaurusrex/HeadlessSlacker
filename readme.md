<p align="center">
<img src="https://raw.githubusercontent.com/refactorsaurusrex/HeadlessSlacker/master/Images/headless-slack.png" />
</p>

# Update!
Slack has released a new version of its Windows app, which reverted the system tray behavior back to the pre-1.1.5 state. In other words, you can once again natively minimize to the tray! Hooray! Sadly, that means Headless Slack is currently obsolete. Wah wahhhh.

## Hacking Slack For Windows

Version 1.1.5 of Slack's Windows application disallowed minimizing to the system tray. The change was made with the goal of ensuring that users never missed any incoming messages. It sounds like a significant number of users were [chronically missing notifications](https://slack-files.com/T024BE7LD-F04DKJP9R-a61c0f491c), so I can certainly appreciate why Slack introduced these modifications. That said, I do wish they had been introduced as *optional* features. Between desktop notifications, the subtle - but very real - system tray icon change when you have unread messages, and mobile notifications, I personally never found myself missing important messages. The inability to minimize to the tray also meant having no escape from the flashing orange taskbar icon that comes along with each message, which I find distracting and visually jarring.

And so I decided to throw this little workaround together...

## Headless Slacker: Installation & Usage

Headless Slacker allows you to escape the oppressive orange flashing (<-- dramatic!) by *optionally* hiding the Slack taskbar icon altogether. Once it's installed, right-click the Slack taskbar icon and select "Hide Taskbar Icon". To unhide, click the red "@" icon floating around in your system tray. (The Headless Slacker icon.)

- [Click here](https://github.com/refactorsaurusrex/HeadlessSlacker/raw/master/HeadlessSlacker/publish/setup.exe) to install the application. (Windows only.) **NOTE 7/29/15:** The application doesn't appear to work with Windows 10 yet. There's an [issue](https://github.com/refactorsaurusrex/HeadlessSlacker/issues/2) you can follow, if you're interested.

- When the application is run, it checks to see if Slack is running. If not, it starts Slack. Once Slack is running, a jump list menu item is added to Slack that says "Hide Taskbar Icon". Clicking this will remove the Slack window from the taskbar and run Headless Slacker in the background, shown as a red "@" symbol in the system tray.

<p align="center">
<img src="https://raw.githubusercontent.com/refactorsaurusrex/HeadlessSlacker/master/Images/HeadlessSlackJumpList.png" />
</p>

- To unhide the Slack icon, click the red "@" icon once.

<p align="center">
<img src="https://raw.githubusercontent.com/refactorsaurusrex/HeadlessSlacker/master/Images/HeadlessSlackTrayIcon.png" />
</p>

- If you quit Slack entirely while Headless Slacker is running, you can click the "@" system tray icon to restart and show Slack.
