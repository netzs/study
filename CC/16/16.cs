1
//Spawn car
private void SpawnCar()

// Шум. Удалить.

2
// if (totalManifoldsCount > 0)
// {
//     Debug.Log(string.Format("total_manifolds_count={0}", totalManifoldsCount));
// }


// Закомментированный код. Удалить.
3
        // Changes to the options object that will be used during build.
        // This means you have access to the Sentry CLI options and also the options that affect the native layer
        // on Android, iOS and macOS
        Debug.Log(nameof(BuildTimeConfiguration) + "::Configure() finished");

// Нелокальная информация. Не относиться к коду. Перенести.

4
//:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
//::  This function converts radians to decimal degrees             :::
//:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

// Позиционные маркеры. Не косая черта, но тоже стоит убрать.

5
MaxDB = 20 * Mathf.Log10(rmsValue / m_refValue); // calculate dB

// Шум. Удалить.

6
/// <param name="arg1">Argument1</param>
/// <param name="arg2">Argument2</param>
/// <param name="arg3">Argument3</param>
/// <param name="arg4">Argument4</param>

// Бормотание. Не несут смысла.

7
// This is actually what triggers the OnValidate() method.
property.FindPropertyRelative("m_EditorAssetChanged").boolValue = false;

// Неочевидные комментарии

8

/// <summary>
/// Avatar asset
/// </summary>
Avatar,

/// <summary>
/// AnimationController asset
/// </summary>
AnimationController,

// Шум

9 
 /// <summary>
 /// Percentage of Efficiency asset usage that uses the entire dependency tree of this bundle dependency.
 /// This includes DependencyBundle and all bundles beneath it.
 /// Value is equal to [Total Filesize of Dependency Assets] / [Total size of all dependency bundles on disk]
 /// Example: There are 3 bundles A, B, and C, that are each 10 MB on disk. A depends on 2 MB worth of assets in B, and B depends on 4 MB worth of assets in C.
 /// The Efficiency of the dependencyLink from A->B would be 2/10 -> 20% and the ExpandedEfficiency of A->B would be (2 + 4)/(10 + 10) -> 6/20 -> 30%
 ///  </summary>
 public float ExpandedEfficiency;

 // Избыточные комментарии. Уменьшить размер.


10
// Setup
buildTasks.Add(new SwitchToBuildPlatform());
buildTasks.Add(new RebuildSpriteAtlasCache());

// Player Scripts
if (compileScripts)
{
    buildTasks.Add(new BuildPlayerScripts());
    buildTasks.Add(new PostScriptsCallback());
}

// Dependency
buildTasks.Add(new PreviewSceneDependencyData());
buildTasks.Add(new CalculateAssetDependencyData());
buildTasks.Add(new StripUnusedSpriteSources());
buildTasks.Add(new CreateBuiltInShadersBundle(builtinShaderBundleName));
buildTasks.Add(new PostDependencyCallback());

// Packing
buildTasks.Add(new GenerateBundlePacking());
buildTasks.Add(new UpdateBundleObjectLayout());
buildTasks.Add(new GenerateLocationListsTask());
buildTasks.Add(new PostPackingCallback());

// -> 

AddTaskSetup();
AddTaskPlayerScripts();
AddTaskDependency();
AddTaskPacking();

// Не используйте комментарии там, где можно использовать функцию или переменную. Разбить на методы с характерным названием. 

11
/// [RequireSpriteDataProvider(typeof(ISpriteOutlineDataProvider), typeof(ITextureDataProvider))]
/// public class MySpriteEditorCustomModule : SpriteEditorModuleBase
/// {
/// ......
/// }

// Закомментированный код. Удалить.


12
/// <summary>Sets a custom texture to be used by the ISpriteEditor during setup of the editing space.</summary>
/// <param name = "texture" > The custom preview texture.</param>
/// <param name = "width" > The width dimension to render the preview texture.</param>
/// <param name = "height" > The height dimension to render the preview texture.</param>
/// <remarks>When the method is called, the editing space's dimensions are set to the width and height values, affecting operations such as Zoom and Pan in the ISpriteEditor view. The preview texture is rendered as the background of the editing space.</remarks>
void SetPreviewTexture(Texture2D texture, int width, int height);

// Обязательные комментарии. Блоки param и remarks следует удалить - не несут смысла.


13
// am I closest to the thingy?

// Слишком много информации. Не относиться к делу. Удалить.


14
} // namespace

// Комментарии за закрывающей фигурной скобкой. Удалить.

15

///////////////////////////////////////////////////////////////////////////
// Test that our results match the C++.
///////////////////////////////////////////////////////////////////////////

// ->

// Test that our results match the C++.

// Позиционные маркеры. Удалить "/".






