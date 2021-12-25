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

        // Anime la page 180 -> 0 (y)
        public static Storyboard AnimatePage(Page page, StackPanel stackPanelPage)
        {
            const string RESSOURCES_ANIMATE_PAGE = "AnimatePage";

            const string TARGET_NAME_PAGE = "Page";
            const string TARGET_PROPERTY_RENDERTRANSFORM_TRANSLATE_Y = "(UIElement.RenderTransform).(CompositeTransform.TranslateY)";
            const string TARGET_PROPERTY_OPACITY = "Opacity";

            const int DURATION_ANIMATION_PAGE = 2;

            const int OPACITY_NONE = 0;
            const int OPACITY_ONE = 1;

            const int TRANSLATE_Y_BEGIN = 180;
            const int TRANSLATE_Y_END = 0;

            Duration duration = new Duration(TimeSpan.FromSeconds(DURATION_ANIMATION_PAGE));

            Storyboard stoyryboardPage = new Storyboard();

            DoubleAnimation doubleAnimationTranslateY = new DoubleAnimation()
            {
                From = TRANSLATE_Y_BEGIN,
                To = TRANSLATE_Y_END,
                Duration = duration
            };

            DoubleAnimation doubleAnimationOpacity = new DoubleAnimation()
            {
                From = OPACITY_NONE,
                To = OPACITY_ONE,
                Duration = duration
            };

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

    }
}
