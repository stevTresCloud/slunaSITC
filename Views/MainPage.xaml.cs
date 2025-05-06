using System.Text.RegularExpressions;

namespace slunaSITC.Views;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();

        idTypePicker.ItemsSource = new List<string>
        {
            "C�DULA",
            "PASAPORTE"
        };

        careerPicker.ItemsSource = new List<string>
        {
            "ADMINISTRACI�N DE EMPRESAS",
            "CIENCIAS DE LA EDUCACI�N B�SICA",
            "CIENCIAS DE LA EDUCACI�N INICIAL",
            "CONTABILIDAD Y AUDITOR�A",
            "DISE�O DIGITAL",
            "ELECTR�NICA Y AUTOMATIZACI�N",
            "INFORM�TICA",
            "MEDICINA",
            "PSICOLOG�A",
            "SISTEMAS DE INFORMACI�N",
            "TELECOMUNICACIONES"
        };

        modalityPicker.ItemsSource = new List<string>
        {
            "PRESENCIAL",
            "SEMIPRESENCIAL",
            "EN L�NEA"
        };
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        string id = identificationEntry.Text?.Trim();
        string idType = idTypePicker.SelectedItem?.ToString();
        string lastName = lastNameEntry.Text?.Trim();
        string middleName = middleNameEntry.Text?.Trim();
        string fullName = fullNameEntry.Text?.Trim();
        string phone = phoneEntry.Text?.Trim();
        string email = emailEntry.Text?.Trim();
        string confirmEmail = confirmEmailEntry.Text?.Trim();
        string career = careerPicker.SelectedItem?.ToString();
        string modality = modalityPicker.SelectedItem?.ToString();
        string campus = campusEntry.Text?.Trim();

        if (!IsNumeric(id) || !IsNumeric(phone))
        {
            await DisplayAlert("Error", "Identificaci�n y tel�fono deben contener solo n�meros.", "OK");
            return;
        }

        if (!IsLetters(lastName) || !IsLetters(middleName) || !IsLetters(fullName))
        {
            await DisplayAlert("Error", "Apellidos y nombres deben contener solo letras.", "OK");
            return;
        }

        if (!IsValidEmail(email) || email != confirmEmail)
        {
            await DisplayAlert("Error", "Los correos no coinciden o el formato es inv�lido.", "OK");
            return;
        }

        var data = new Models.StudentForm
        {
            IdType = idType,
            Identification = id,
            LastName = lastName,
            MiddleName = middleName,
            FullName = fullName,
            Phone = phone,
            Email = email,
            ConfirmEmail = confirmEmail,
            Career = career,
            Modality = modality,
            Campus = campus
        };

        await DisplayAlert("�xito", "Datos guardados correctamente.", "OK");
    }

    bool IsNumeric(string value) => Regex.IsMatch(value ?? string.Empty, @"^\d+$");
    bool IsLetters(string value) => Regex.IsMatch(value ?? string.Empty, @"^[a-zA-Z������������\s]+$");
    bool IsValidEmail(string email) => Regex.IsMatch(email ?? string.Empty, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
}