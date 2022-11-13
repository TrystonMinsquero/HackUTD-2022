using TMPro;
using UnityEngine;

namespace UI
{
    public class UI_ClubAdmin : MonoBehaviour
    {
        [SerializeField] private UI_Controller _controller;
        [SerializeField] private TMP_Text clubAbbr;
        [SerializeField] private TMP_Text clubName;
        [SerializeField] private TMP_InputField nameInput;
        [SerializeField] private TMP_InputField dateInput;
        [SerializeField] private TMP_InputField timeInput;
        [SerializeField] private TMP_InputField descInput;
        [SerializeField] private TMP_InputField locInput;

        
        private void OnValidate()
        {
            if (!_controller) _controller = FindObjectOfType<UI_Controller>();
        }

        public void CreateEvent()
        {
            AddEvent(_controller.user.ownClub, 
                nameInput.text, 
                dateInput.text, 
                timeInput.text, 
                descInput.text, 
                locInput.text);
        }

        private void AddEvent(ClubObject club, string eventName, string date, string time, string description, string location)
        {
            club.events.Add(
                new EventObject(
                    eventName,
                    club.abbreviation,
                    date,
                    time,
                    description,
                    location));
        }
    }
}