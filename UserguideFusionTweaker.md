# Userguide FusionTweaker #
## Installation ##
To use the tool and it's built-in service, you need to obviously install the given files from the Download section. It could be, that you need to download and install Microsofts .NET Framework 4 upfront, but only in case, it can't be found.
If you already have a previous version of the FusionTweaker installed, I strongly suggest to uninstall it first.

## Tabs ##
Once it has started up, you will see a window eleven different tabs. The eight tabs on the left belong to states, which the CPU can be in, while the next two tabs show the setup for the two available NB (Northbridge) PStates. The last, but not least, is the status tab, which can be used for debug and more detailed info on the internal registers.

http://fusiontweaker.googlecode.com/files/FusionTweakerV105.PNG

## CPU PStates ##
Let's start with the first eight tabs.
You can see the current active PState looking to the right of the bars . The available PStates are called P0 .. P7. PState P0 is always the fastest mode, while P7 is the slowest one. Depending on the current workload of your system, it will switch dynamically between them. As you can imagine, P0 is drawing more current than P7, which is directly related to battery life you can get.

### Voltage ###
With the tool, you can now customize the voltage, which goes into your CPU (CPU VID) for each of the available PStates. Furthermore you can change the divider to get to a different CPU clock than stock.

You can start with the following changes (example from a Samsung notebook with A6-3410MX APU:
  * P0 - 2.3GHz - 1.15V
  * P1 - 1.6GHz - 0.95V
  * P2 - 1.5GHz - 0.925V
  * P3 - 1.4GHz - 0.9V
  * P4 - 1.3GHz - 0.875V
  * P5 - 1.2GHz - 0.8375V
  * P6 - 1.0GHz - 0.8V
  * P7 - 0.8GHz - 0.75V

With these settings, I've lowered the wattage by about 10-15% at full load and saw about 5°C lower APU temperatures.

If you click "Apply" on the below right, these settings will be temporary set, until you restart or put your system into sleep. You can check the settings by using a well known tool called CPU-Z.

If everything looks alright, you can download Prime95, which is program to do some stress testing. Doing that, tells you, if the system is really stable in most cases. It avoids getting blue screens or freezes later, which can be really annoying.

One should stress each of the PStates separately. This can be achieved by going into advanced Power Options of Win7.

Just check, while running the stress test, if you are always in the Pstate its supposed to be in. If you do the stress testing, please don't open any important documents. It can happen, that files get damaged, if the system hung up (rare, but possible).

In case, the systems hangs during testing, you know the selected voltage was too low for that PState. Just simply hold the power button for a few second and your system restarts without the modified voltages.
After restart increase voltage a bit and start stressing the system again. I strongly suggest, not to use a voltage for later use, which is just one step away from, where it hung up. Please add about 25mV at least to have some margin.

Once all that is done and everything runs smoothly, **and only in that case**, you can click on the "Service..." button. Before you read on, please consider looking at this: DeactiveService. By setting that up, there will be a service in the background, which applies the adjusted voltages after coming out of sleep or while booting Win.
You just need to click "Update" to get the current settings, check the selection box "Make custom P-state settings permanent" and hit "Apply".
Now you are done.

### Clock/Divider ###
If you want, you can play around with the dividers to adjust used clocks for each PState. For example, I let my system run for a while on 400MHz, while lowering the voltage to about 0.7V.
Unfortunately you can't overclock by using lower dividers, since the CPU seems to internally lock them to a specific value.
  * Example:
  * E-350 - 1.6GHz
  * FSB 100MHz
  * Multiplier 32x
  * Divider 2
  * Maximum clock 32/2\*100MHz = 1600MHz

Even though you can select a divider smaller than 2 on an E-350, the CPU blocks that and just runs stil at 1.6GHz!

## NB PStates ##

### Voltage ###
Because the NB (Northbridge) and the GPU (graphic unit) are sharing a separate powersupply, it is worth looking into lowering this voltage in addition to gain some more battery life.
Basically the adjustments you can do, need to be done the same way as for the CPU, except that only two PStates are available.
On my system, the following settings work stable:
  * NB P0 - 0.85V
  * NB P1 - 0.8V

Just a little lower and it hangs. Just press the Power button for a while and it will get back to life.

### Clock/Divider ###
There is no opportunity to mess with the dividers on the NB so far.

If you like this application and you want to support my work, please donate.<br>
<a href='https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=MXVAJLM9ABXC4'><img src='https://www.paypal.com/en_US/i/btn/btn_donateCC_LG.gif' /></a>