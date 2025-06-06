<?php 
      require_once 'core/init.php';

?>

<html lang=en>

<head>
    <link rel="shortcut icon" href="redCircle.ico">
    <title>Schedule</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="Employe website">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/fullcalendar/3.4.0/fullcalendar.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.0.0-alpha.6/css/bootstrap.css" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jqueryui/1.12.1/jquery-ui.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.18.1/moment.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/fullcalendar/3.4.0/fullcalendar.min.js"></script>
    <link rel="stylesheet" type="text/css" href="css/schedule_styling.css">
    <script>
        $(document).ready(function() {
            var calendar = $('#calendar').fullCalendar({
                editable: true,
                weekNumbers: true,
                firstDay: 1,
                header: {
                    left: 'title',
                    center: 'prev,next today',
                    right: 'month,agendaWeek,agendaDay'
                },
                events: 'includes/load.php',
                selectable: true,
                selectHelper: true,
                
                
                

                select: function(start, end, allDay) {

                    $("#start")[0].value = $.fullCalendar.formatDate(start, "Y-MM-DD");
                    $("#end")[0].value = $.fullCalendar.formatDate(end, "Y-MM-DD");

                    if($("#start")[0].value != $("#end")[0].value){
                        calendar.fullCalendar("unselect");
                        $("#end")[0].value = $("#start")[0].value;
                            if($("#start")[0].value == $("#end")[0].value){
                            var modal = document.getElementById("scheduling");
                            modal.style.display = "block";

                            var span = document.getElementsByClassName("close")[0];

                            span.onclick = function() {
                            modal.style.display = "none";
                            }

                            window.onclick = function(event) {
                            if (event.target == modal) {
                                modal.style.display = "none";
                                }
                            }
                        }
                    }
                },
               
                eventClick: function(event, start) {
                    var id = event.id;
                    var title = event.title;
                    if (confirm("Are you sure you want to remove the " + title + " preference ?")) {
                        $.ajax({
                            url: "includes/delete.php",
                            type: "POST",
                            data: {
                                id: id,
                                title: title
                            },
                            success: function() {
                                calendar.fullCalendar('refetchEvents');
                                alert("Event Removed");
                            }
                        })
                    }
                },

            });
        });

        function disable() {
            var checkBox = document.getElementById("check");
            if (checkBox.checked == true){
                document.getElementById("checks1").disabled = true;
                document.getElementById("checks2").disabled = true;
                document.getElementById("checks3").disabled = true;
            } else {
                document.getElementById("checks1").disabled = false;
                document.getElementById("checks2").disabled = false;
                document.getElementById("checks3").disabled = false;
            }
        }

    </script>
</head>

<body>
    <div class="wrapper">
        <div class="header">
            <ul>
                <li><a href="schedule.php">Schedule</a></li>
                <li><a href="account.php">Account</a></li>
                
                <li><a href="includes/logout.php"><button type="submit" name="submit">Sign Out</button></a></li>
            </ul>
        </div>
        <div class="instructions">
            <p> If multiple days are selected, only the first day of your selection will be added to your preferences. </p>

        </div>
        <div class="content">
            <div id="calendar"></div>
        </div>
    </div>

        <!-- The Modal -->
<div id="scheduling" class="modal">

  <!-- Modal content -->
  <div class="modal-content">
    <div class="modal-header">
      <h2>Schedule Preference</h2>
      <span class="close">&times;</span>
    </div>
    <br>
    <div class="modal-body">
        <form action="includes/insert.php" method="POST">
            <input type="checkbox" id="checks1" name="morning" value="Morning">
            <label class="option"> Morning</label>
            <input type="checkbox" id="checks2" name="afternoon" value="Afternoon">
            <label class="option"> Afternoon</label>
            <input type="checkbox" id="checks3" name="evening" value="Evening">
            <label class="option"> Evening</label><br>
            <input type="checkbox" id="check" name="vacation" value="Vacation" onchange="disable()">
            <label class="option"> Vacation</label><br><br>

            <input type="hidden" name="start" id="start" value="">
            <input type="hidden" name="end" id="end" value="">
            <input type="submit" id="submit" class="submit" value="Submit">
        </form>
          <br>
    </div>
  </div>

</div>
</body>

</html>