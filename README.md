# RockMvvmForms
RockMvvmForms, a very simple framework for Xamarin.Forms projects.

Principles:

- Not IoC implemented. Just a basic Service Locator is included RockServiceLocator.
- Separate completaly the Views from the ViewModels with the static class ViewFactory.
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
             RockServiceLocator.Current.Register<IMarvelApiService, MarvelApiService> ();
         }
 
         private void RegisterViews()
         {
            ViewFactory.Register<FirstViewModel, FirstView> ();
            ViewFactory.Register<DetailViewModel, DetailView> ();
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

The ViewFactory is a static class and this is how to register your ViewModels and Views:

```c#
private void RegisterViews()
{
    ViewFactory.Register<FirstViewModel, FirstView> ();
    ViewFactory.Register<DetailViewModel, DetailView> ();
}
```

# RockServiceLocator

This is a basic Service Locator. The reason of creating my own Service Locator and not to use DependencyService is because to use DependencyService you need to execute Forms.Init() and this is a bad choice if you want to have your Unit Tests in a nUnit Library Project. This is how to use it:

```c#
// Register
private void RegisterServices()
{
    RockServiceLocator.Current.Register<IMarvelApiService, MarvelApiService> ();
}

// Resolve
private readonly IMarvelApiService _marvelService;
public FirstViewModel ()
{
     _marvelService = RockServiceLocator.Current.Get<IMarvelApiService>();
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

