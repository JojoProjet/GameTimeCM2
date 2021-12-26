using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace GameTimeCM2.Src.Utils
{
    class Animation
    {

        private const int DURATION_ANIMATION_PAGE = 2;

        private const int TRANSLATE_Y_BEGIN = 180;
        private const int TRANSLATE_Y_END = 0;

        private const int OPACITY_NONE = 0;
        private const int OPACITY_ONE = 1;

        private const string TARGET_PROPERTY_RENDERTRANSFORM_TRANSLATE_Y = "(UIElement.RenderTransform).(CompositeTransform.TranslateY)";
        private const string TARGET_PROPERTY_OPACITY = "Opacity";

        private static DoubleAnimation CreateDoubleAnimation(int from, int to)
        {
            Duration duration = new Duration(TimeSpan.FromSeconds(DURATION_ANIMATION_PAGE));

            return new DoubleAnimation()
            {
                From = from,
                To = to,
                Duration = duration
            };
        }


        // Anime la page 180 -> 0 (y)
        public static Storyboard AnimatePage(Page page, StackPanel stackPanelPage)
        {
            const string RESSOURCES_ANIMATE_PAGE = "AnimatePage";

            const string TARGET_NAME_PAGE = "Page";

            Storyboard stoyryboardPage = new Storyboard();

            DoubleAnimation doubleAnimationTranslateY = CreateDoubleAnimation(TRANSLATE_Y_BEGIN, TRANSLATE_Y_END);
            DoubleAnimation doubleAnimationOpacity = CreateDoubleAnimation(OPACITY_NONE, OPACITY_ONE);

            stoyryboardPage.Children.Add(doubleAnimationTranslateY);
            stoyryboardPage.Children.Add(doubleAnimationOpacity);

            Storyboard.SetTargetName(doubleAnimationTranslateY, stackPanelPage.Name);
            Storyboard.SetTargetName(doubleAnimationOpacity, stackPanelPage.Name);

            Storyboard.SetTargetProperty(doubleAnimationTranslateY, TARGET_PROPERTY_RENDERTRANSFORM_TRANSLATE_Y);
            Storyboard.SetTargetProperty(doubleAnimationOpacity, TARGET_PROPERTY_OPACITY);

            if(!page.Resources.ContainsKey(RESSOURCES_ANIMATE_PAGE))
                page.Resources.Add(RESSOURCES_ANIMATE_PAGE, stoyryboardPage);

            Storyboard storyboard = page.Resources[RESSOURCES_ANIMATE_PAGE] as Storyboard;

            return storyboard;

        }

        public static Storyboard AnimateEmoji(Page page, StackPanel image)
        {
            Storyboard storyboardEmoji = new Storyboard();

            DoubleAnimation doubleAnimationTranslateY = CreateDoubleAnimation(TRANSLATE_Y_BEGIN, TRANSLATE_Y_END);
            DoubleAnimation doubleAnimationOpacity = CreateDoubleAnimation(OPACITY_NONE, OPACITY_ONE);

            storyboardEmoji.Children.Add(doubleAnimationTranslateY);
            storyboardEmoji.Children.Add(doubleAnimationOpacity);

            Storyboard.SetTargetName(doubleAnimationTranslateY, image.Name);
            Storyboard.SetTargetName(doubleAnimationOpacity, image.Name);

            Storyboard.SetTargetProperty(doubleAnimationTranslateY, TARGET_PROPERTY_RENDERTRANSFORM_TRANSLATE_Y);
            Storyboard.SetTargetProperty(doubleAnimationOpacity, TARGET_PROPERTY_OPACITY);

            if (!page.Resources.ContainsKey($"Animate{image.Name}"))
                page.Resources.Add($"Animate{image.Name}", storyboardEmoji);

            Storyboard storyboard = page.Resources[$"Animate{image.Name}"] as Storyboard;

            return storyboard;

        }



    }
}
