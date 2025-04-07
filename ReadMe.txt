*** InventoryApp solution Consists of four layers:
	1. InventoryApp Layer:
		- ViewModels => Contains our logic code that separated from views.xaml
		- Views => Contains our UI and related logic separated from business logic and db calls exists inside ViewModels
		- RelayCommand => implements ICommand interface to bind UI controls to command logic in the ViewModel

	2. InventoryApp.Common Layer
		- Models => Our Models that's used in ViewModels and Views
		- Interfaces => In our project it contains only Repos interfaces and it's impelementation is in infra layer

	3. InventoryApp.Infrastructure Layer
		- Peristance => Repos Implementation, EF Configurations, Migrations

	4. Unit Tests for VMs using xUnit and Moq libraries

*** Uses MVVM architecture

chosen technologies => WPF, .Net 8, EF, xUnit, Moq

***Notes***
- I WAS TOLD THAT THIS POSITION IS MAINLY FOR BE .Net WHICH IS MY FOCUS
- BUT I SEE THAT THIS TASK IS MAINLY FOR WPF WHICH I WORKED WITH IT BUT THIS WAS 6 YEARS AGO IN THE FIRST COMPANY I WORKED AT
- When YOU TRY TO EDIT AN ITEM YOU HAVE TO SELECT IT FIRST, THE EDIT BUTTON IS ENABLED ALL THE TIME, SO IF BUTTON IS CLICKED WITHOUT SELECTING AN ITEM IT WILL
DO NO ACTION
- THE VALIDATION FOR NAME AND STOCK QUANTITY IS NOT APPLIED, BUT ALL OTHER REQUIREMENTS ARE DONE

