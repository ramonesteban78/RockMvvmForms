# RockMvvmForms
RockMvvmForms, a superlight framework for Xamarin.Forms projects.

Principles:

- Use DependencyService as our service locator for the whole solution. Not IoC implemented.
- Separate completaly the Views from the ViewModels.
- Navigation happens in the ViewModel.

# Initial setup

Just install the nuget package `Install-Package RockMvvmForms` in your PCL project.

Create 2 private functions to register services and Views in your Application Forms class as follows:

```c#
public partial class App : Application
     {
         private IViewFactory _viewFactory;
 
         public App ()
         {
             InitializeComponent (); 
 
             // Register the services in the Forms Service Locator
             RegisterServices ();
 
             // Register the ViewModels and asociate them to the corresponding Views
             RegisterViews ();
 
             // The root page of your application
             MainPage = new RockNavigationPageService<FirstViewModel>().Create();
         }
 
         private void RegisterServices()
         {
             DependencyService.Register<IViewFactory, ViewFactory> ();
             DependencyService.Register<IMarvelApiService, MarvelApiService> ();
         }
 
         private void RegisterViews()
         {
             _viewFactory = DependencyService.Get<IViewFactory> ();
 
             _viewFactory.Register<FirstViewModel, FirstView> ();
             _viewFactory.Register<DetailViewModel, DetailView> ();
         }
 
         protected override void OnStart ()
         {
             // Handle when your app starts
         }
 
         protected override void OnSleep ()
         {
             // Handle when your app sleeps
         }
 
         protected override void OnResume ()
         {
             // Handle when your app resumes
         }
             
     }
```
# ViewFactory

The ViewFactory is the repository for ViewModels and Views. 

The ViewFactory is registered in the DependencyService ViewModels as follows:

```c#
private void RegisterServices()
{
     DependencyService.Register<IViewFactory, ViewFactory> ();
     DependencyService.Register<IMarvelApiService, MarvelApiService> ();
}
 
private void RegisterViews()
{
    _viewFactory = DependencyService.Get<IViewFactory> ();
 
    _viewFactory.Register<FirstViewModel, FirstView> ();
    _viewFactory.Register<DetailViewModel, DetailView> ();
}
```

# ViewModels

The ViewModels have to inherit from ViewModelBase class in order to use them using RockMvvmForms. Once we have done this we access the following capabilities:

- `Navigation` - Navigation Service implementation of Xamarin.Forms. 
  - `PopAsync`
  - `PopModalAsync`
  - `PushAsync`
  - `PushModalAsync`
  - `DisplayAlert`
  - `DisplayActionSheet`

- `InitAsync` - You can override the InitAsync method of the ViewModelBase. This method is executed after the ViewModel constructor and before the View is displayed.

- `View_Appearing` - You can override this Event which is happening when the View in appearing.

- `View_Disappering` - You can override the disappering event of the View. 

Example of how to use the Navigation at the ViewModel:

```c#
this.Navigation.PushAsync<DetailViewModel> (new DetailViewModel (character));
```

# Rock Pages Services

To access manually to the ViewFactory, the MainPage initialization it's being done through a Page Services for ContentPages, NavigationPages and MasterDetailPages. These are: `RockNavigationPageService`, `RockContentPageService` and `RockMasterDetailPageService`. 
My intention is to create new Page Services for Tab pages and Caruossel pages and will be available in future versions.

Enjoy!

