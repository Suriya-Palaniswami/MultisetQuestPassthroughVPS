# Multiset VPS Quest Sample

Welcome to the **Multiset VPS Quest Sample** project. This repository demonstrates how to integrate the [Multiset Quest SDK](https://docs.multiset.ai/multiset-quest-sdk/installation-guide) into a Unity application for Meta Quest devices and leverage Multiset’s Visual Positioning System (VPS) for centimeter-accurate localisation.

---

## 🚀 What You Can Build

* Real-time user localisation in physical space
* Virtual objects anchored to precise real-world positions
* Spatial mapping, navigation, and location-aware AR/VR experiences

---

## 📋 Prerequisites

| Requirement              | Details                          |
| ------------------------ | -------------------------------- |
| **Unity**                | 6.0 or newer (≥ 6000.0.55f1)     |
| **Platform Support**     | Android Build Support module     |
| **Target Device**        | Meta Quest 3 / Quest 3 S         |
| **Network**              | Stable internet connection       |
| **API Credentials**      | Client ID & Secret from Multiset |
| **Experience**           | Basic Unity development          |

---

## ⚙️ Setup Guide

Follow the steps below to add the SDK, configure your project, and run the sample scene.

### 1. Clone or open the project

```bash
# clone this repo (or simply open the folder with Unity Hub)
```

### 2. Add the Multiset Quest SDK package (Git URL – recommended)

1. Open **Window → Package Manager**.
2. Click the **➕** button → **Add package from Git URL…**.
3. Enter the repository URL:

   ```
   https://github.com/MultiSet-AI/multiset-quest-sdk.git
   ```
4. Press **Add**. After installation, **Multiset Quest SDK** appears under **In Project**.

> The SDK automatically installs its own dependencies (Meta XR Core, glTFast, OpenXR Plugin, etc.).

### 3. Import the sample scenes *(optional but recommended)*

1. In **Package Manager**, select **Multiset Quest SDK**.
2. Open the **Samples** tab → click **Import** next to **Sample Scenes**.
3. Imported scenes live at:

   ```
   Assets/Samples/Multiset Quest SDK/<version>/Single Frame Localization/Scenes/
   ```

### 4. Configure the SDK

1. **API Credentials**  
   Open:

   ```
   Assets/Samples/Multiset Quest SDK/<version>/Single Frame Localization/Resources/MultiSetConfig.asset
   ```
   Populate `Client Id` and `Client Secret` from your Multiset Developer Dashboard.

2. **XR Plugin Management**  
   * `Edit → Project Settings → XR Plug-in Management` – install if prompted.
   * **Enable** **OpenXR** for the Android platform.

3. **Switch Platform to Android**  
   * `File → Build Settings → Android → Switch Platform`.
   * Back in **XR Plug-in Management**, run **Project Validation** and click **Fix All**.
   * In **Project Settings → Meta XR → Project Setup Tool**, press **Fix All**.
     (Generates `Assets/Plugins/Android/AndroidManifest.xml` with required permissions.)

4. **Map or MapSet Configuration**  
   * Open the sample scene (`SingleFrameLocalization.unity`).
   * Select **MultisetSdkManager** in the Hierarchy.
   * In **SingleFrameLocalizationManager**, choose **Map** or **MapSet** and enter your code(s).
   * Place all AR content under the **Map Space** GameObject so it anchors correctly.

5. **Download Map Mesh (Authoring Aid)**  
   Use the **Map Mesh Downloader** component to fetch environment meshes for in-editor authoring. See the docs page for details.

6. **Camera Permissions**  
   Ensure `AndroidManifest.xml` contains:

   ```xml
   <uses-permission android:name="horizonos.permission.HEADSET_CAMERA" />
   ```
   Unity will also prompt for camera access on first run.

---

## 🏗️ Build & Deploy

1. `File → Build Settings` → **Android** → **Add Open Scenes**.
2. **Player Settings**:
   * Scripting Backend: **IL2CPP**
   * Target Architectures: **ARM64**
   * Minimum API Level: **32+**
3. Connect your Quest headset (developer mode enabled) and click **Build and Run**.
4. On-device, grant camera permission and test localisation.

---

## 🛠️ Troubleshooting

| Issue                            | Fix / Check                                                         |
| -------------------------------- | ------------------------------------------------------------------- |
| Package Manager errors           | Update Unity Hub & Editor to latest versions                        |
| XR Plugin validation warnings    | Restart Unity & rerun **Project Validation**                        |
| Build failures                   | Ensure **Fix All** passed, API Level ≥ 32, IL2CPP + ARM64           |
| Credential errors                | Re-enter Client ID / Secret, verify dashboard access                |
| Localization not working         | Stable internet, correct Map/MapSet codes, good lighting           |
| Camera permission denied         | Re-run app, allow camera in Quest settings                          |

---

## 📚 References

* Official docs – [Multiset Quest SDK Installation Guide](https://docs.multiset.ai/multiset-quest-sdk/installation-guide)
* Multiset Developer Portal – <https://developer.multiset.ai>

---

## ✨ Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

---

## © License

This sample is provided for educational purposes and may include assets licensed from third-party sources. Refer to individual asset licenses where applicable.

