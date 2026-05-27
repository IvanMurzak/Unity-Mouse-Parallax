# Unity-Mouse-Parallax
![npm](https://img.shields.io/npm/v/extensions.unity.mouse.parallax) [![openupm](https://img.shields.io/npm/v/extensions.unity.mouse.parallax?label=openupm&registry_uri=https://package.openupm.com)](https://openupm.com/packages/extensions.unity.mouse.parallax/) ![License](https://img.shields.io/github/license/IvanMurzak/Unity-Mouse-Parallax) [![Stand With Ukraine](https://raw.githubusercontent.com/vshymanskyy/StandWithUkraine/main/badges/StandWithUkraine.svg)](https://stand-with-ukraine.pp.ua)

Unity Parallax based on mouse input. Alternative version to [Unity-Gyroscope-Parallax](https://github.com/IvanMurzak/Unity-Gyroscope-Parallax).

### Features
- ✔️ support legacy Input System
- ✔️ support new Input System
- ✔️ move/rotate objects based on mouse input
- ✔️ ability to add custom controllers

![Short Demo](https://user-images.githubusercontent.com/9135028/198884624-d8dacd24-41db-4488-b33c-59102809c336.gif)

<details>
  <summary>Full demo video</summary>
  
https://user-images.githubusercontent.com/9135028/198884331-8e084cda-77bb-427a-bb6a-7d6af585b26f.mp4

</details>


# MouseMover2D
Moves list of objects using mouse input.

![Unity_2OiBF8IwNI](https://user-images.githubusercontent.com/9135028/198884833-761cd597-f749-4d02-8742-7fdf46c6144c.png)

# MouseRotator2D
Rotates list of objects using mouse input.

![Unity_uWbnrUEaR2](https://user-images.githubusercontent.com/9135028/198884825-d3b2872e-5331-4519-afe6-9061b80ebd8c.png)

# Installation

### Option 1 - Installer

- **[⬇️ Download Installer](https://github.com/IvanMurzak/Unity-Mouse-Parallax/releases/latest/download/Unity-Mouse-Parallax-Installer.unitypackage)**
- **📂 Import installer into Unity project**
  > - You may use double click on the file - Unity will open it
  > - OR: You may open Unity Editor first, then click on `Assets/Import Package/Custom Package`, then choose the file

### Option 2 - OpenUPM-CLI

- [⬇️ Install OpenUPM-CLI](https://github.com/openupm/openupm-cli#installation)
- 📟 Open command line in Unity project folder

```bash
openupm add extensions.unity.mouse.parallax
```

### Option 3 - Manual (manifest.json)

- Add this code to `/Packages/manifest.json`

```json
{
  "dependencies": {
    "extensions.unity.mouse.parallax": "1.0.5"
  },
  "scopedRegistries": [
    {
      "name": "package.openupm.com",
      "url": "https://package.openupm.com",
      "scopes": [
        "extensions.unity",
        "com.cysharp",
        "com.ivanmurzak"
      ]
    }
  ]
}
```

# How to use
- add needed `Mouse...2D` component to any GameObject
- link Targets to list of targets
- press 'Play' button in Unity Editor
