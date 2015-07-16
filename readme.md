## Hacking Slack For Windows

Version 1.1.5 of Slack's Windows application introduced two changes with the goal of ensuring that users never missed any incoming messages: First, minimizing to the system tray was disabled; second, incoming notifications caused the taskbar icon to flash and then remain orange.

It sounds like a significant number of users were [chronically missing notifications](https://slack-files.com/T024BE7LD-F04DKJP9R-a61c0f491c), so I can certainly appreciate why Slack introduced these modifications. That said, I do wish they had been introduced as *optional* features. Between desktop notifications, the subtle - but very real - system tray icon change when you have unread messages, and mobile notifications, I personally never found myself missing important messages.

And so I decided to throw this little workaround together...

## Installation & Usage

Headless Slack allows you to escape the oppressive orange flashing (<-- dramatic!) by *optionally* hiding the Slack taskbar icon altogether. Once it's installed, right-click the Slack taskbar icon and select "Hide Taskbar Icon".
