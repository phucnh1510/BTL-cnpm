<script>
    import "../CSS/assignment.css";
    import * as Resizable from "$lib/components/ui/resizable";

    import Header from "../components/Header.svelte";
    import Coding1 from "../codeForStudents/coding1.svelte";
    import Coding2 from "../codeForStudents/coding2.svelte";

    import AssignmentHeader from "../components/AssignmentHeader.svelte";

</script>

<main class="h-screen w-screen">
    <AssignmentHeader />
    
    <Resizable.PaneGroup direction="horizontal" class="assignment-pane-group-horizontal h-full w-full  ">
    <Resizable.Pane defaultSize={50} class="assignment-pane assignment-pane-one resizable-1 h-full">
        <div class="assignment-content assignment-content-one  h-full items-center justify-center p-1">
            <Coding1 />
        </div>
    </Resizable.Pane>
    <Resizable.Handle class="assignment-handle-horizontal" />
    <Resizable.Pane defaultSize={50} class="assignment-pane assignment-pane-two resizable-1 h-full">
        <Resizable.PaneGroup direction="vertical" class="assignment-pane-group-vertical h-full">
            <Resizable.Pane defaultSize={50} class="assignment-pane assignment-pane-three h-full">
                <div class="assignment-content assignment-content-two flex  items-center justify-center p-1">
                    <Coding2 />
                </div>
            </Resizable.Pane>
            
        </Resizable.PaneGroup>
    </Resizable.Pane>
</Resizable.PaneGroup>
</main>

<style>
    .assignment-pane {
        background-color: black;
    }

    .assignment-content {
        background-color: black;
    }

    .assignment-font {
        font-size: 1.5rem;
    }

    .assignment-pane-one {
        background-color: black;
    }

    .assignment-pane-two {
        background-color: black;
    }

    .assignment-pane-three {
        background-color: black;
    }

    .assignment-pane-four {
        background-color: black;
    }

    .assignment-pane-group-horizontal {
        background-color: black;
    }

    .assignment-pane-group-vertical {
        background-color: black;
    }

    .assignment-handle-horizontal {
        background-color: black;
        
    }

    .assignment-handle-vertical {
        background-color: black;
    }
</style>
